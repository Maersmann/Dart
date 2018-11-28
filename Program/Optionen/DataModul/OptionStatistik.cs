using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm.Optionen.DataModul
{
    public class OptionStatistik
    {
        public int HighscoreListSize { get; set; }
        public int HighfinishListSize { get; set; }

        public OptionStatistik()
        {
            HighscoreListSize = 10;
            HighfinishListSize = 10;
        }
    }
}
