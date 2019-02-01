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
        private string _path;
        public enum Segno { c, b, d, s };


        public Carta(int v, Segno s, string path)
        {
            _valore = v;
            _segno = s;
            _path = path;
        }
    }
}
