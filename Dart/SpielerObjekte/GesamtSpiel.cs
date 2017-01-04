using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.SpielerObjekte
{
    public class GesamtSpiel
    {
        public Double PunktZahl { get; set; }
        public Double Wuerfe { get; set; }
        public Double Average { get; set; }

        public GesamtSpiel()
        {
            Wuerfe = 0;
            PunktZahl = 0;
            Average = 0;
        }
    }
}
