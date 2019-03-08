using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;

namespace Sette_e_mezzo_Gruppo_1
{
    public class Giocatore : IComparable<Giocatore>
    {
        private string _nick;
        private int _soldi;
        private int _puntata;
        public double _reDiDenara;
        private BitmapImage avatar;
        public List<Carta> _carte;
        //proprietà utili nel cambio mazziere e nell'azzeramento della puntata
        public string Nick { get => _nick; set => _nick= value; }
        public int Soldi { get => _soldi; set => _soldi = value; }
        public int Puntata { get => _puntata; set => _puntata = value; }
        public BitmapImage Avatar { get => avatar; set => avatar = value; }

        public Giocatore(string nick, int soldi = 100)
        {
            Nick = nick;
            Soldi = soldi;
            _carte = new List<Carta>();
            _reDiDenara = 0;
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

        public override string ToString()
        {
            return Nick + "|" + Soldi;
        }

        public int CompareTo(Giocatore other)
        {
            if (other == null)
            {
                return 1;
            }else if(this == null)
            {
                return -1;
            }else if(this==null && other== null)
            {
                return 0;
            }
            if(other.Soldi==this.Soldi)
            {
                return 0;
            }
            else if(other.Soldi<this.Soldi)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
