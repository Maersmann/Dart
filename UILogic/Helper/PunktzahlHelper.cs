using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.Helper
{
    public class PunktzahlHelper
    {
        public static int PunkzahlToIndex( int inPunktzahl )
        {
            switch (inPunktzahl)
            {
                case  301: return 0;
                case  501: return 1;
                case  701: return 2;
                case  901: return 3;
                case 1001: return 4;
                default: return 1;
            }

        }

        public static int IndexToPunktzahl(int inPunktzahl)
        {
            switch (inPunktzahl)
            {
                case 0: return 301;
                case 1: return 501;
                case 2: return 701;
                case 3: return 901;
                case 4: return 1001;
                default: return 501;
            }

        }
    }
}
