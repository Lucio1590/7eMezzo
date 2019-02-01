using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sette_e_mezzo_Gruppo_1
{
    class Mazziere : Giocatore
    {
        public List<Carta> carte;
        public Mazziere(string nick):base(nick)
        {

        }

        private void CostruisciListaCarte()
        {
            Carta.Segno segno = Carta.Segno.b;
            Carta carta;

            for (int i = 0; i < 40; i++)
            {
                switch (i)
                {
                    case 10:
                        segno = Carta.Segno.c;
                        break;
                    case 20:
                        segno = Carta.Segno.d;
                        break;
                    case 30:
                        segno = Carta.Segno.s;
                        break;
                }
                carta = new Carta(i, segno, "Carte/" + i.ToString() + segno.ToString() + ".png");
                carte.Add(carta);
            }
        }        
    }
}
