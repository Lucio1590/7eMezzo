using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sette_e_mezzo_Gruppo_1
{
    public class Carta
    {
        private int _valore;
        private Segno _segno;
        private string _percorsoImmagineCarta;

        public string PercorsoImmagineCarta { get => _percorsoImmagineCarta; set => _percorsoImmagineCarta = value; }
        public int Valore { get => _valore; set => _valore = value; }
        internal Segno Segno1 { get => _segno; set => _segno = value; }

        public enum Segno { c, b, d, s };


        public Carta(int v, Segno s, string path)
        {
            Valore = v;
            Segno1 = s;
            PercorsoImmagineCarta = path;
        }
    }
}
