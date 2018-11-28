using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programm.MatchViews.Matchobjekte;

namespace Programm.MatchUtils
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

            _ListHighFinish.Add(new Wert() { Anzahl = 1, Score = pWurf });
            _ListHighFinish = _ListHighFinish.OrderByDescending(o => o.Score).ToList();

            if (_ListHighFinish.Count() > inListSize)
            {
                _ListHighFinish.RemoveAt(_ListHighFinish.Count() - 1);
            }
        }

        public List<Wert> getListHighFinish() { return _ListHighFinish; }

    }
}
