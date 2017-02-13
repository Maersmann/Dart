using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dart.Optionen.DataModul
{
    public class OptionGame
    {
        public int LegZumSet { get; set; }
        public int SetZumSieg { get; set; }
        public int Punktzahl { get; set; }

        public OptionGame()
        {
            LegZumSet = 3;
            SetZumSieg = 5;
            Punktzahl = 501;
        }
    }
}
