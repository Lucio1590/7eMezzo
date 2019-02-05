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

        public void CambiaMazziere()
        {
            for(int i=0; i<_giocatori.Length; i++)
            {
                if(_giocatori[i] is Mazziere)
                {
                    Giocatore aus;
                    for(int j=0; j<i; j++)
                    {
                        if (j == 0)
                        {
                            _giocatori[_giocatori.Length - 1] = _giocatori[j];
                        }
                        else
                        {
                            aus = _giocatori[j - 1];
                            _giocatori[j - 1] = _giocatori[j];
                            _giocatori[j] = null;
                        }
                    }
                    break;
                }
            }
        }
        
    }
}
