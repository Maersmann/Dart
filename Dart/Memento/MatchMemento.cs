using Dart.MatchViews;
using Repository.MatchEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Memento
{
    public class MatchMemento
    {
        private Match _Match;
        private int _AnzahlSpieler;
        private int _AktuellerSpielerPos;

        private int _SpielerLegBegonnen;
        private int _SpielerSetBegonnen;

        private int _ListSizeFinish;
        private int _ListSizeScore;

        public MatchMemento(Match pMatch, int pAnzahlSpieler, int pAktuellerSpielerPos, int pSpielerLegBegonnen, int pSpielerSetBegonnen, int inListSizeFinish, int inListSizeScore)
        {
            _Match = pMatch;
            _AnzahlSpieler = pAnzahlSpieler;

            _AktuellerSpielerPos = pAktuellerSpielerPos;
            _SpielerLegBegonnen = pSpielerLegBegonnen;
            _SpielerSetBegonnen = pSpielerSetBegonnen;

            _ListSizeFinish = inListSizeFinish;
            _ListSizeScore = inListSizeScore;

        }

        public MatchModel getMatchModel()
        {
            return new MatchModel(_Match , _AnzahlSpieler, _AktuellerSpielerPos , _SpielerLegBegonnen, _SpielerSetBegonnen, _ListSizeFinish, _ListSizeScore);
        }
    }
}
