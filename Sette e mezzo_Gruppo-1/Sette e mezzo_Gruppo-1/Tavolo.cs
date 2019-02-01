using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sette_e_mezzo_Gruppo_1
{
    class Tavolo
    {
        List<Giocatore> _giocatori;
        Mazziere _mazziere;

        public Tavolo(Mazziere m)
        {
            _giocatori = new List<Giocatore>();
            _mazziere = m;
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
    }
}
