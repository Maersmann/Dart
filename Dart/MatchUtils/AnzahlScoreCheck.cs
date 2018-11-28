using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programm.MatchUtils
{
    class AnzahlScoreCheck
    {

        private int _AnzahlSechzig;
        private int _AnzahlHundert;
        private int _AnzahlHundertVierzig;
        private int _AnzahlHundertAchtzig;
        private int _AnzahlHundertSiebzig;

        public AnzahlScoreCheck(int pAnzahlSechzig, int pAnzahlHundert, int pAnzahlHundertVierzig, int pAnzahlHundertAchtzig,int pAnzahlHundertSiebzig, int pWurf)
        {
            _AnzahlSechzig = pAnzahlSechzig;
            _AnzahlHundert = pAnzahlHundert;
            _AnzahlHundertVierzig = pAnzahlHundertVierzig;
            _AnzahlHundertAchtzig = pAnzahlHundertAchtzig;
            _AnzahlHundertSiebzig = pAnzahlHundertSiebzig;

            if (pWurf == 180 )
            {
                _AnzahlHundertAchtzig ++;
            }
            else if(pWurf >= 170)
            {
                _AnzahlHundertSiebzig++;
            }
            else if (pWurf >= 140 )
            {
                _AnzahlHundertVierzig++;
            }
            else if (pWurf >= 100)
            {
                _AnzahlHundert++;
            }
            else if (pWurf >= 60)
            {
                _AnzahlSechzig++;
            }
        }

        public int getAnzahlSechzig() { return _AnzahlSechzig; }

        public int getAnzahlHundert() { return _AnzahlHundert; }

        public int getAnzahlHundertVierzig() { return _AnzahlHundertVierzig; }

        public int getAnzahlHundertAchtzig() { return _AnzahlHundertAchtzig; }

        public int getAnzahlHundertSiebzig() { return _AnzahlHundertSiebzig; }
    }
}
