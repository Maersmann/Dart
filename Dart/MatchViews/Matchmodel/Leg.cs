using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm.MatchViews.Matchobjekte
{
    public class Leg
    {
        public int Nummer { get; set; }
        public Double Wuerfe { get; set; }
        public Double Punktzahl { get; set; }
        public Double Average { get; set; }

        public Leg()
        {
            Nummer = 0;
            Wuerfe = 0;
            Punktzahl = 0;
            Average = 0;
        }
    }
}
