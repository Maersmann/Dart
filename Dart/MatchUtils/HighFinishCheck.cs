using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.MatchUtils
{
    public class HighFinishCheck
    {
        private int[] _ListHighFinish;
        private int[] _ListAnzahl;

        public HighFinishCheck(int[] pListHighFinish, int[] pListAnzahl, int pWurf)
        {
            _ListHighFinish = pListHighFinish;
            _ListAnzahl = pListAnzahl;

            if (_ListHighFinish[0] < pWurf)
            {
                if (_ListHighFinish.Contains(pWurf))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (_ListHighFinish[i] == pWurf)
                        {
                            _ListAnzahl[i]++;
                            return;
                        }
                    }
                }

                int WurtTemp, WurfAnzahlTemp;
                _ListHighFinish[0] = pWurf;
                _ListAnzahl[0] = 1;

                for (int i = 0; i <= 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (_ListHighFinish[j] > _ListHighFinish[j + 1])
                        {
                            WurtTemp = _ListHighFinish[j + 1];
                            _ListHighFinish[j + 1] = _ListHighFinish[j];
                            _ListHighFinish[j] = WurtTemp;

                            WurfAnzahlTemp = _ListAnzahl[j + 1];
                            _ListAnzahl[j + 1] = _ListAnzahl[j];
                            _ListAnzahl[j] = WurfAnzahlTemp;
                        }
                    }
                }
            }
        }

        public int[] getListHighFinish() { return _ListHighFinish; }

        public int[] getListAnzahl() { return _ListAnzahl; }
    }
}
