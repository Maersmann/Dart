using Dart.Match;
using Dart.Match.Matchobjekte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Memento
{
    public class MatchMemento
    {
        private MatchObjekt _Match;
        private int _AnzahlSpieler;
        private int _AktuellerSpielerPos;

        private int _SpielerLegBegonnen;
        private int _SpielerSetBegonnen;

        public MatchMemento(MatchObjekt pMatch, int pAnzahlSpieler, int pAktuellerSpielerPos, int pSpielerLegBegonnen, int pSpielerSetBegonnen)
        {
            _Match = pMatch;
            _AnzahlSpieler = pAnzahlSpieler;

            _AktuellerSpielerPos = pAktuellerSpielerPos;
            _SpielerLegBegonnen = pSpielerLegBegonnen;
            _SpielerSetBegonnen = pSpielerSetBegonnen;

        }

        public MatchModel getMatchModel()
        {
            return new MatchModel(_Match , _AnzahlSpieler, _AktuellerSpielerPos , _SpielerLegBegonnen, _SpielerSetBegonnen);
        }
    }
}
