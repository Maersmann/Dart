using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.MatchObjekte
{
    public class MatchObjekt
    {
        public int LegZumSet { get;  }
        public int SetZumSieg { get; }
        public int PunktZahlzumLeg { get; }

        public MatchObjekt(int pSetZumSieg , int pLegZumSet, int pPunktZahlzumLeg)
        {
            LegZumSet = pLegZumSet;
            SetZumSieg = pSetZumSieg;
            PunktZahlzumLeg = pPunktZahlzumLeg;
        }
            
    }

}
