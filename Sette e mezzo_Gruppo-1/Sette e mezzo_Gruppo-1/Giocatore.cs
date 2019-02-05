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

        public int Soldi { get => _soldi; set => _soldi = value; }
        public int Puntata { get => _puntata; set => _puntata = value; }

        public Giocatore(string nick, int soldi = 100)
        {
            _nick = nick;
            _carte = new List<Carta>();
        }

        public void AccettaCarta()
        {

        }

        public void RifiutaCarta()
        {

        }
    }
}
