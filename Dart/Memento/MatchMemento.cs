using Dart.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Memento
{
    public class MatchMemento
    {
        private List<Spieler> _SpielerListe;
        private Spieler _AktuellenSpieler;
        private int _AnzahlSpieler;
        private int _AktuellerSpielerPos;

        private int _SpielerLegBegonnen;
        private int _SpielerSetBegonnen;

        public MatchMemento(List<Spieler> pSpielerListe, Spieler pAktuellenSpieler, int pAnzahlSpieler, int pAktuellerSpielerPos, int pSpielerLegBegonnen, int pSpielerSetBegonnen)
        {
            _SpielerListe = pSpielerListe;
            _AnzahlSpieler = pAnzahlSpieler;

            _AktuellenSpieler = pAktuellenSpieler;
            _AktuellerSpielerPos = pAktuellerSpielerPos;
            _SpielerLegBegonnen = pSpielerLegBegonnen;
            _SpielerSetBegonnen = pSpielerSetBegonnen;

        }

        public MatchModel getMatchModel()
        {
            return new MatchModel(_SpielerListe, _AktuellenSpieler , _AnzahlSpieler, _AktuellerSpielerPos , _SpielerLegBegonnen, _SpielerSetBegonnen);
        }
    }
}
