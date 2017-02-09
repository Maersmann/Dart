using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dart.Match.Matchobjekte;

namespace Dart.MatchUtils
{
    public class HighFinishCheck
    {
        private List<Wert> _ListHighFinish;

        public HighFinishCheck(List<Wert> pListHighFinish, int pWurf, int inListSize)
        {
            _ListHighFinish = pListHighFinish;


            foreach (Wert wert in _ListHighFinish)
            {
                if (wert.Score == pWurf)
                { 
                    wert.Anzahl++;
                    return;
                }
            }

            Wert WertTemp;
            _ListHighFinish.Add(new Wert() { Anzahl = 1, Score = pWurf });

            for (int i = 0; i < _ListHighFinish.Count() - 1; i++)
            {
                for (int j = 0; j < _ListHighFinish.Count() - 1; j++)
                {
                    if (_ListHighFinish[j].Score > _ListHighFinish[j + 1].Score)
                    {
                        WertTemp = _ListHighFinish[j + 1];
                        _ListHighFinish[j + 1] = _ListHighFinish[j];
                        _ListHighFinish[j] = WertTemp;
                    }
                }
            }
        }

        public List<Wert> getListHighFinish() { return _ListHighFinish; }

    }
}
