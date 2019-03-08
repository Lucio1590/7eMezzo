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
    public class Mazziere : Giocatore
    {
        private List<Carta> _carteMazziere;

        public List<Carta> CarteMazziere { get => _carteMazziere; set => _carteMazziere = value; }

        public Mazziere(string nick) : base(nick)
        {
            CarteMazziere = new List<Carta>();
            CostruisciListaCarte();
            //var shuffledcards = _carte.OrderBy(a => Guid.NewGuid()).ToList();
        }

        
        public Mazziere(string nick, int soldi) : base(nick, soldi) //costruttore secondario per il cambio mazziere
        {
            _carte = new List<Carta>();
            CostruisciListaCarte();
        }
        

        private void CostruisciListaCarte()
        {
            Carta.Segno segno = Carta.Segno.b;
            Carta carta;
            string segnoToString="b";
            for (int i = 1; i < 41; i++)
            {
                switch (i)
                {
                    case 10:
                        segno = Carta.Segno.c;
                        segnoToString = "c";
                        break;
                    case 20:
                        segno = Carta.Segno.d;
                        segnoToString = "d";
                        break;
                    case 30:
                        segno = Carta.Segno.s;
                        segnoToString = "s";
                        break;
                }
                if (i == 10)
                {
                    carta = new Carta(10, segno, "Carte/" + (10).ToString() + segnoToString + ".png");
                }
                else
                {
                    carta = new Carta(i%10, segno, "Carte/" + (i%10).ToString() + segnoToString + ".png");
                }
                CarteMazziere.Add(carta);
            }
        }

        public Carta DaiCarta()
        {
            Random r = new Random();
            Carta c = CarteMazziere[r.Next(0,CarteMazziere.Count)];
            CarteMazziere.Remove(c);
            return c;
        }
    }
}
