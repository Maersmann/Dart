using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Match.Matchobjekte
{
    public class Set
    {
        public List<Leg> Legs { get; set; }
        public int Nummer { get; set; }
        public Double Wuerfe;
        public Double Punktzahl;
        public Double Average;

        public Set()
        {
            Punktzahl = 0;
            Wuerfe = 0;
            Average = 0;
            Nummer = 0;
            Legs = new List<Leg>();
        }
    }
}
