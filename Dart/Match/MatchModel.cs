using Dart.Memento;
using Dart.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dart.Match.Matchobjekte;
using Dart.Optionen.Utils;

namespace Dart.Match
{
    public class MatchModel
    {
        MatchObjekt _Match;

        private MatchSpieler _AktuellenSpieler;
        private int _AnzahlSpieler;
        private int _AktuellerSpielerPos;

        private int _SpielerLegBegonnen;
        private int _SpielerSetBegonnen;

        private int _ListSizeFinish;
        private int _ListSizeScore;

        public bool Spielbeendet { get; set; }


        public MatchModel( MatchObjekt pMatch )
        {
            Spielbeendet = false;
            OptionIni optIni = new OptionIni();
            _ListSizeFinish = optIni.OptionStatistik.HighfinishListSize;
            _ListSizeScore = optIni.OptionStatistik.HighscoreListSize;

            _Match = pMatch;

            _AnzahlSpieler = _Match.SpielerList.Count;

            _AktuellenSpieler = _Match.SpielerList[0];
            _AktuellerSpielerPos = 0;
            _SpielerLegBegonnen = _AktuellerSpielerPos;
            _SpielerSetBegonnen = _AktuellerSpielerPos;
        }

        public MatchModel( MatchObjekt pMatch , int pAnzahlSpieler, int pAktuellerSpielerPos, int pSpielerLegBegonnen, int pSpielerSetBegonnen)
        {
            _Match = pMatch;
            _AnzahlSpieler = pAnzahlSpieler;

            _AktuellenSpieler = _Match.SpielerList[pAktuellerSpielerPos];
            _AktuellerSpielerPos = pAktuellerSpielerPos;
            _SpielerLegBegonnen = pSpielerLegBegonnen;
            _SpielerSetBegonnen = pSpielerSetBegonnen;

        }

        public void NaechsterSpieler()
        {
            _Match.SpielerList[_AktuellerSpielerPos] = _AktuellenSpieler;
            if (_AktuellerSpielerPos < _AnzahlSpieler-1)
            {    
                _AktuellerSpielerPos++; 
            }
            else
            {
                _AktuellerSpielerPos = 0;
            }
            _AktuellenSpieler = _Match.SpielerList[_AktuellerSpielerPos];
        }

        public MatchMemento getMemento()
        {
            MatchObjekt matchMemento = _Match.getMatchMemento();
          
            return new MatchMemento(matchMemento, _AnzahlSpieler, _AktuellerSpielerPos ,_SpielerLegBegonnen ,_SpielerSetBegonnen );
        }


        public void PunktzahlZurueckSetzen()
        {
            foreach (MatchSpieler spieler in _Match.SpielerList)
            {
                spieler.AktuellePunktZahl = _Match.PunktZahlzumLeg;
            }
        }

        public void LegBeendet()
        {
            foreach (MatchSpieler spieler in _Match.SpielerList)
            {

                int LetzteLegNummer = spieler.AktuellesLeg.Nummer;
                spieler.AktuellesSet.Legs.Add(spieler.AktuellesLeg);
                spieler.AktuellesLeg = new Leg();
                spieler.AktuellesLeg.Nummer = (LetzteLegNummer+1);
            }
        }

        public void SetBeendet()
        {
            foreach (MatchSpieler spieler in _Match.SpielerList)
            {
                int LetzteSetNummer = spieler.AktuellesSet.Nummer;
                spieler.Sets.Add(spieler.AktuellesSet);

                spieler.AktuellesSet = new Set();
                spieler.AktuellesLeg.Nummer = 1;
                spieler.AktuellesSet.Nummer = (LetzteSetNummer + 1);
                spieler.AnzahlLegGewonnen = 0;
            }
        }

        public void SetSpielerNachLeg()
        {
            if (_SpielerLegBegonnen < _AnzahlSpieler - 1)
            {
                _SpielerLegBegonnen++;
            }
            else
            {
                _SpielerLegBegonnen = 0;
            }
            _AktuellerSpielerPos = _SpielerLegBegonnen;
            _AktuellenSpieler = _Match.SpielerList[_AktuellerSpielerPos];
        }

        public void SetSpielerNachSet()
        {
            if (_SpielerSetBegonnen < _AnzahlSpieler - 1)
            {
                _SpielerSetBegonnen++;
            }
            else
            {
                _SpielerSetBegonnen = 0;
            }  
            _SpielerLegBegonnen = _SpielerSetBegonnen;
            _AktuellerSpielerPos = _SpielerSetBegonnen;
            _AktuellenSpieler = _Match.SpielerList[_AktuellerSpielerPos];
        }

        public void SpeichereSpiel()
        {
            SaveGame save = new SaveGame(_Match);
            foreach (MatchSpieler spieler in _Match.SpielerList)
            {
                save.NeuerSpieler(spieler);
            }
            save.SchliesseDatei();

        }

        #region Getter/Setter
        public String getName()
        {
            return _AktuellenSpieler.Spieler.GetName();
        }

        public int getGewonnenLegs()
        {
            return _AktuellenSpieler.AnzahlLegGewonnen;
        }   

        public int getGewonnenSet()
        {
            return _AktuellenSpieler.AnzahlSetGewonnen;
        }

        public int getAnzahlSechzig()
        {
            return _AktuellenSpieler.Statistiken.Sechzig;
        }

        public int getAnzahlHundert()
        {
            return _AktuellenSpieler.Statistiken.Hundert;
        }

        public int getAnzahlHundertVierzig()
        {
            return _AktuellenSpieler.Statistiken.HundertVierzig;
        }

        public int getAnzahlHundertAchzig()
        {
            return _AktuellenSpieler.Statistiken.HundertAchzig;
        }

        public Double getAverageSpiel()
        {
            return _AktuellenSpieler.AverageMatch;
        }

        public Double getAverageLeg()
        {
            return _AktuellenSpieler.AktuellesLeg.Average;
        }

        public Double getAverageSet()
        {
            return _AktuellenSpieler.AktuellesSet.Average;
        }

        public Double getLegWuerfe()
        {
            return _AktuellenSpieler.AktuellesLeg.Wuerfe;
        }

        public Double getLegPunktzahl()
        {
            return _AktuellenSpieler.AktuellesLeg.Punktzahl;
        }

        public Double getSetWuerfe()
        {
            return _AktuellenSpieler.AktuellesSet.Wuerfe;
        }

        public Double getSetPunktzahl()
        {
            return _AktuellenSpieler.AktuellesSet.Punktzahl;
        }

        public Double getGeamtWuerfe()
        {
            return _AktuellenSpieler.WuerfeMatch;
        }

        public Double getGesamtPunktzahl()
        {
            return _AktuellenSpieler.PunktzahlMatch;
        }

        public int getPunktestand()
        {
            return _AktuellenSpieler.AktuellePunktZahl;
        }

        public List<Wert> getListHighScore()
        {
            return _AktuellenSpieler.Statistiken.Highscore;
        }

        public List<Wert> getListHighFinish()
        {
            return _AktuellenSpieler.Statistiken.Highfinish;
        }

        public int getAnzahlHundertSiebzig()
        {
            return _AktuellenSpieler.Statistiken.HundertSiebzig;
        }

        public int getAnzahlSpieler()
        {
            return _AnzahlSpieler;
        }

        public int getListSizeFinish()
        {
            return _ListSizeFinish;
        }

        public int getListSizeScore()
        {
            return _ListSizeScore;
        }

        public void setAnzahlHundertSiebzig(int pHundertSiebzig)
        {
            _AktuellenSpieler.Statistiken.HundertSiebzig = pHundertSiebzig;
        }

        public void setShortestLeg(double pShortestLeg)
        {
            _AktuellenSpieler.Statistiken.ShortesLeg = pShortestLeg;
        }

        public void setLongestLeg(double pLongestLeg)
        {
            _AktuellenSpieler.Statistiken.LongestLeg = pLongestLeg;
        }

        public double getShortestLeg()
        {
            return _AktuellenSpieler.Statistiken.ShortesLeg;
        }

        public double getLongestLeg()
        {
            return _AktuellenSpieler.Statistiken.LongestLeg;
        }


        public List<MatchSpieler> getSpielerList()
        {
            return _Match.SpielerList;
        }

        public int getLegZumSet()
        {
            return _Match.LegZumSet;
        }

        public int getSetZumSieg()
        {
            return _Match.SetZumSieg;
        }

        public void setGewonnenLegs(int pLeg)
        {
            _AktuellenSpieler.AnzahlLegGewonnen = pLeg;
        }

        public void setGewonnenSet(int pSet)
        {
            _AktuellenSpieler.AnzahlSetGewonnen = pSet;
        }

        public void setAnzahlSechzig(int pAnzahlSechzig)
        {
            _AktuellenSpieler.Statistiken.Sechzig = pAnzahlSechzig;
        }

        public void setAnzahlHundert(int pAnzahlHundert)
        {
            _AktuellenSpieler.Statistiken.Hundert = pAnzahlHundert;
        }

        public void setAnzahlHundertVierzig(int pAnzahlHundertVierzig)
        {
            _AktuellenSpieler.Statistiken.HundertVierzig = pAnzahlHundertVierzig;
        }

        public void setAnzahlHundertAchzig(int pAnzahlHundertAchzig)
        {
            _AktuellenSpieler.Statistiken.HundertAchzig = pAnzahlHundertAchzig;
        }

        public void setAverageSpiel(Double pAverageSpiel)
        {
            _AktuellenSpieler.AverageMatch = pAverageSpiel;
        }

        public void setAverageLeg(Double pAverageLeg)
        {
            _AktuellenSpieler.AktuellesLeg.Average = pAverageLeg;
        }

        public void setAverageSet(Double pAverageSet)
        {
            _AktuellenSpieler.AktuellesSet.Average = pAverageSet;
        }

        public void setLegWuerfe(Double pWuerfe)
        {
            _AktuellenSpieler.AktuellesLeg.Wuerfe = pWuerfe;
        }

        public void setLegPunktzahl(Double pPunktzahl)
        {
            _AktuellenSpieler.AktuellesLeg.Punktzahl = pPunktzahl;
        }

        public void setSetWuerfe(Double pWuerfe)
        {
            _AktuellenSpieler.AktuellesSet.Wuerfe = pWuerfe;
        }

        public void setSetPunktzahl(Double pPunktzahl)
        {
            _AktuellenSpieler.AktuellesSet.Punktzahl = pPunktzahl;
        }

        public void setGesamtWuerfe(Double pWuerfe)
        {
            _AktuellenSpieler.WuerfeMatch = pWuerfe;
        }

        public void setGesamtPunktzahl(Double pPunktzahl)
        {
            _AktuellenSpieler.PunktzahlMatch = pPunktzahl;
        }

        public void setPunkteStand(int punktestand)
        {
            _AktuellenSpieler.AktuellePunktZahl = punktestand;
        }

        public void setListHighScore(List<Wert> pListHighScore)
        {
            _AktuellenSpieler.Statistiken.Highscore = pListHighScore;
        }

        public void setListHighFinish(List<Wert> pListHighFinish)
        {
            _AktuellenSpieler.Statistiken.Highfinish = pListHighFinish;
        }

        #endregion
    }
}
