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
    }
}
