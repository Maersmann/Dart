using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dart.MatchViews.Matchobjekte;

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

            _ListHighScore.Add(new Wert() { Anzahl = 1, Score = pWurf });
            _ListHighScore = _ListHighScore.OrderByDescending(o => o.Score).ToList();

            if (_ListHighScore.Count() > inListSize)
            {
                _ListHighScore.RemoveAt(_ListHighScore.Count()-1);
            }

        }

        public List<Wert> getListHighScore() { return _ListHighScore; }

    }
}
