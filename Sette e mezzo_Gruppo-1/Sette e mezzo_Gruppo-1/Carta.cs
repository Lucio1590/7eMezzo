using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sette_e_mezzo_Gruppo_1
{
    class Carta
    {
        private int _valore;
        private Segno _segno;
        public enum Segno { coppe, bastoni, denara, spade };
        
        public Carta(int v, Segno s)
        {
            _valore = v;
            _segno = s;
        }
    }
}
