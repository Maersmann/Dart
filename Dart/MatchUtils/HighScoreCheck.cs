using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dart.Match.Matchobjekte;

namespace Dart.MatchUtils
{
    public class HighScoreCheck
    {
        private List<Wert> _ListHighScore;


        public HighScoreCheck(List<Wert> pListHighScore, int pWurf, int inListSize )
        {
            _ListHighScore = pListHighScore;


            foreach (Wert wert in _ListHighScore)
            {
                if (wert.Score == pWurf)
                {
                    wert.Anzahl++;
                    return;
                }
            }

            Wert WertTemp;
            _ListHighScore.Add( new Wert() { Anzahl = 1, Score = pWurf } );

            for (int i = 0; i < _ListHighScore.Count() - 1; i++)
            {
                for (int j = 0; j < (_ListHighScore.Count() - 1 - i); j++)
                {
                    if (_ListHighScore[j].Score > _ListHighScore[j + 1].Score)
                    {
                        WertTemp = _ListHighScore[j + 1];
                        _ListHighScore[j + 1] = _ListHighScore[j];
                        _ListHighScore[j] = WertTemp;
                    }
                }
            }
        }

        public List<Wert> getListHighScore() { return _ListHighScore; }

    }
}
