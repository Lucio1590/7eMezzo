using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sette_e_mezzo_Gruppo_1
{
    class Tavolo
    {
        Giocatore [] _giocatori;
        Mazziere _mazziere;

        public Tavolo()
        {
            _giocatori = new Giocatore[11];
        }
        /// <summary>
        /// Metodo che viene richiamato con l'avvio di una nuova partita,
        /// si occupa di azzerare la puntata di ogni giocatore , 
        /// togliere ogni carta da ogni giocatore 
        /// e il richiamo del metodo del cambio mazziere poichè 
        /// ad ogni partita il mazziere cambia 
        /// </summary>
        public void NuovaPartita()
        {
            foreach (Giocatore g in _giocatori)
            {
                //azzera puntata
                g.Puntata = 0;
                //togli carte dai giocatori 
                foreach (Carta c in g._carte)
                {
                    g._carte.Remove(c);
                }
            }
            //richiama cambio mazziere 
            CambiaMazziere();
        }
        /// <summary>
        /// Metodo di rimozione di un giocatore
        /// </summary>
        /// <returns></returns>
        public void RimuoviGiocatore(Giocatore g)
        {
            for(int i=0; i<_giocatori.Length; i++)
            {
                if (_giocatori[i] == g)
                {
                    _giocatori[i] = null;
                }
            }
        }
        /// <summary>
        /// Metodo di Aggiunta di un giocatore
        /// </summary>
        /// <param name="g"></param>
        public void AggiungiGiocatore(Giocatore g, int pos)
        {
            _giocatori[pos] = g;
        }
        /// <summary>
        /// Metodo di cambio del mazziere e di slittamento di tutti i giocatori all'interno dell'array
        /// </summary>

        public void CambiaMazziere()
        {
            for(int i=0; i<_giocatori.Length; i++)
            {
                if(_giocatori[i] is Mazziere)
                {
                    Giocatore aus=null;
                    for(int j=0; j<i; j++)
                    {
                        if (j == 0)
                        {
                            aus = _giocatori[_giocatori.Length - 1];
                            _giocatori[_giocatori.Length - 1] = _giocatori[j];
                        }
                        else
                        {
                            _giocatori[j - 1] = _giocatori[j];
                            _giocatori[j] = null;
                        }
                    }
                    if (i != _giocatori.Length - 1)
                    {
                        Mazziere m = new Mazziere(_giocatori[i+1].Nick, _giocatori[i+1].Soldi);
                        Giocatore g = new Giocatore(_giocatori[i].Nick, _giocatori[i].Soldi);
                        _giocatori[i] = m;
                        _mazziere = m;
                        _giocatori[i - 1] = g;
                    }
                    else
                    {
                        Mazziere m = new Mazziere(_giocatori[0].Nick, _giocatori[0].Soldi);
                        Giocatore g = new Giocatore(_giocatori[i].Nick, _giocatori[i].Soldi);
                        _giocatori[_giocatori.Length] = m;
                        _mazziere = m;
                        _giocatori[i - 1] = g;
                    }
                    for(int j=i+1; j<_giocatori.Length; j++)
                    {
                        if (j == _giocatori.Length - 1 && aus!=null)
                        {
                            _giocatori[j] = aus;
                        }
                    }
                    break;
                }
            }
        }

        public void AssegnaCartaAGiocatore(Giocatore g)
        {
            g.AccettaCarta(_mazziere.DaiCarta());
        }
        //fine Funzione
    }
}
