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
        new private List<Carta> _carte;
        public Mazziere(string nick) : base(nick)
        {
            _carte = new List<Carta>();
            CostruisciListaCarte();
            //var shuffledcards = _carte.OrderBy(a => Guid.NewGuid()).ToList();
        }

        
        public Mazziere(string nick, int soldi) : base(nick, soldi) //costruttore secondario per il cambio mazziere
        {
            _carte = new List<Carta>();
            CostruisciListaCarte();
        }

        public List<Carta> Carte { get => _carte; set => _carte = value; }

        private void CostruisciListaCarte()
        {
            Carta.Segno segno = Carta.Segno.b;
            Carta carta;
            string segnoToString="b";
            for (int i = 0; i < 40; i++)
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
                carta = new Carta(i, segno, "Carte/" + i.ToString() + segnoToString + ".png");
                _carte.Add(carta);
            }
        }

        public Carta DaiCarta()
        {
            Random r = new Random();
            Carta c = Carte[r.Next(0,Carte.Count)];
            Carte.Remove(c);
            return c;
        }
    }
}
