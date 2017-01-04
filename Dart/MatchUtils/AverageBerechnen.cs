using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.MatchUtils
{
    public class AverageBerechnen
    {

        private Double _Wuerfe;
        private Double _Average;
        private Double _Punktzahl;
            
        public AverageBerechnen(Double pBenoetigteWuerfe, Double pGeworfenePunkte, Double pAktuelleWuerfe, Double pAktuellePunkte)
        {
            _Punktzahl = pAktuellePunkte + pGeworfenePunkte;
            _Wuerfe = pBenoetigteWuerfe + pAktuelleWuerfe;
            _Average = _Punktzahl / _Wuerfe * 3.0;

        }

        public Double getAverage() { return Math.Round(_Average,2); }

        public Double getWuerfe() { return Math.Round(_Wuerfe,2); }

        public Double getPunktzahl() { return Math.Round(_Punktzahl,2); }
    }
}
