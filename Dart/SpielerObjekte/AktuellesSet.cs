using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.SpielerObjekte
{
    public class AktuellesSet
    {
        public Double Punktzahl { get; set; }
        public Double Wuerfe { get; set; }
        public Double Average { get; set; }


        public AktuellesSet()
        {
            Punktzahl = 0;
            Wuerfe = 0;
            Average = 0;
        }
    }
}
