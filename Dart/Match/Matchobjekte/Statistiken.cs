using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.Match.Matchobjekte
{
    public class Statistiken
    {
        public int Sechzig { get; set; }
        public int Hundert { get; set; }
        public int HundertVierzig { get; set; }
        public int HundertAchzig { get; set; }
        public int HundertSiebzig { get; set; }
        public double ShortesLeg { get; set; }
        public double LongestLeg { get; set; }

        public Statistiken()
        {
            Sechzig = 0;
            Hundert = 0;
            HundertVierzig = 0;
            HundertAchzig = 0;
            HundertSiebzig = 0;

            ShortesLeg = 0;
            LongestLeg = 0;
        } 

    }
}
