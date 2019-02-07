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
        public double _reDiDenara;
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
            _reDiDenara = 0.5;
        }

        public bool AccettaCartaAndGetReDenara(Carta c)
        {
            _carte.Add(c);
            if(c.Segno1.ToString().Equals("d") && c.Valore == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool SforaLimite()
        {
            if (GetPunteggioTotale() > 7.5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetPunteggioTotale()
        {
            double tot = 0;
            for(int i=0; i<_carte.Count; i++)
            {
                if (_carte[i].Valore == 10 && _carte[i].Segno1.ToString().Equals("d"))
                {
                    tot += _reDiDenara;
                }
                else if (_carte[i].Valore <8)
                {
                    tot += _carte[i].Valore;
                }
                else
                {
                    tot += 0.5;
                }
            }
            return tot;
        }
    }
}
