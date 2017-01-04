using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.SpielerObjekte
{
    public class Speicher
    {
        public List<List<AktuellesLeg>> ListLegAverage { get; set; }
        public List<AktuellesLeg> ListLegAktuell { get; set; }

        public List<AktuellesSet> ListSetAverage { get; set; }

        public Speicher()
        {
            ListLegAverage = new List<List<AktuellesLeg>>();
            ListSetAverage = new List<AktuellesSet>();
            ListLegAktuell = new List<AktuellesLeg>();
        }
    }

}
