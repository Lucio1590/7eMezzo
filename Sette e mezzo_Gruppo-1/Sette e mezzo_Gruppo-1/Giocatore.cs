using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sette_e_mezzo_Gruppo_1
{
    class Giocatore
    {
        private string _nick;
        private int _soldi;
        private int _puntata;
        public List<Carta> _carte;
        //proprietà utili nel cambio mazziere e nell'azzeramento della puntata
        public string Nick { get => _nick; set => _nick= value; }
        public int Soldi { get => _soldi; set => _soldi = value; }
        public int Puntata { get => _puntata; set => _puntata = value; }

        public Giocatore(string nick, int soldi = 100)
        {
            Nick = nick;
            Soldi = soldi;
            _carte = new List<Carta>();
        }

        public void AccettaCarta(Carta c)
        {

        }
        
    }
}
