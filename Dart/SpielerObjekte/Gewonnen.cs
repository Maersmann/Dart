using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.SpielerObjekte
{
    public class Gewonnen
    {
        public int Leg { set; get; }
        public int Set { set; get; }
        public double ShortesLeg { get; set; }
        public double LongestLeg { get; set; }


        public Gewonnen()
        {
            Leg = 0;
            Set = 0;
            ShortesLeg = 0;
            LongestLeg = 0;
        }
    }
}
