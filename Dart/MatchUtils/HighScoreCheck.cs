using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.MatchUtils
{
    public class HighScoreCheck
    {
        private int[] _ListHighScore;
        private int[] _ListAnzahl;

        public HighScoreCheck(int[] pListHighScore, int[] pListAnzahl, int pWurf)
        {
            _ListHighScore = pListHighScore;
            _ListAnzahl = pListAnzahl;

            if (_ListHighScore[0] < pWurf)
            {
                if (_ListHighScore.Contains(pWurf))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (_ListHighScore[i] == pWurf)
                        {
                            _ListAnzahl[i]++;
                            return;
                        }
                    }
                }

                int WurtTemp, WurfAnzahlTemp;
                _ListHighScore[0] = pWurf;
                _ListAnzahl[0] = 1;

                for (int i = 0; i <= 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if(_ListHighScore[j] > _ListHighScore[j+1])
                        {
                            WurtTemp = _ListHighScore[j+1];
                            _ListHighScore[j+1] = _ListHighScore[j];
                            _ListHighScore[j] = WurtTemp;

                            WurfAnzahlTemp = _ListAnzahl[j+1];
                            _ListAnzahl[j+1] = _ListAnzahl[j];
                            _ListAnzahl[j] = WurfAnzahlTemp;
                        }
                    }
                }
            }
        }

        public int[] getListHighScore() { return _ListHighScore; }

        public int[] getListAnzahl() { return _ListAnzahl; }
    }
}
