using Dart.MatchObjekte;
using Dart.Memento;
using Dart.SpielerObjekte;
using Dart.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.Match
{
    public class MatchModel
    {
        private List<Spieler> _SpielerListe;
        private Spieler _AktuellenSpieler;
        private int _AnzahlSpieler;
        private int _AktuellerSpielerPos;

        private int _SpielerLegBegonnen;
        private int _SpielerSetBegonnen;


        public MatchModel(List<Spieler> pSpielerListe)
        {
            _SpielerListe = pSpielerListe;
            _AnzahlSpieler = _SpielerListe.Count;

            _AktuellenSpieler = pSpielerListe.First();
            _AktuellerSpielerPos = 0;
            _SpielerLegBegonnen = _AktuellerSpielerPos;
            _SpielerSetBegonnen = _AktuellerSpielerPos;
        }

        public MatchModel(List<Spieler> pSpielerListe, Spieler pAktuellenSpieler, int pAnzahlSpieler, int pAktuellerSpielerPos, int pSpielerLegBegonnen, int pSpielerSetBegonnen)
        {
            _SpielerListe = pSpielerListe;
            _AnzahlSpieler = pAnzahlSpieler;

            _AktuellenSpieler = pAktuellenSpieler;
            _AktuellerSpielerPos = pAktuellerSpielerPos;
            _SpielerLegBegonnen = pSpielerLegBegonnen;
            _SpielerSetBegonnen = pSpielerSetBegonnen;

        }

        public void NaechsterSpieler()
        {
            _SpielerListe[_AktuellerSpielerPos] = _AktuellenSpieler;
            if (_AktuellerSpielerPos < _AnzahlSpieler-1)
            {    
                _AktuellerSpielerPos++; 
            }
            else
            {
                _AktuellerSpielerPos = 0;
            }
            _AktuellenSpieler = _SpielerListe[_AktuellerSpielerPos];
        }

        public MatchMemento getMemento()
        {
            // return new MatchMemento(_SpielerListe,_AktuellenSpieler,3,1,5,8);

            List<Spieler> temp = new List<Spieler>();

            foreach (Spieler spieler in _SpielerListe)
            {
                temp.Add(spieler.getSpielerMemento());
            }
            Spieler SpielerMemento = temp[_AktuellerSpielerPos];

            return new MatchMemento( temp, SpielerMemento, _AnzahlSpieler, _AktuellerSpielerPos ,_SpielerLegBegonnen ,_SpielerSetBegonnen );
        }

        public void LegZurueckSetzen()
        {
            foreach (Spieler spieler in _SpielerListe)
            {
                spieler.AktuellesLeg = new AktuellesLeg();
            }
        }

        public void SetZurueckSetzen()
        {
            foreach (Spieler spieler in _SpielerListe)
            {
                spieler.Gewonnen.Leg = 0;
                spieler.AktuellesSet = new AktuellesSet();
            }
        }

        public void PunktzahlZurueckSetzen()
        {
            foreach (Spieler spieler in _SpielerListe)
            {
                spieler.AktuellePunktZahl = 501;
            }
        }

        public void LegSpeichern()
        {
            foreach (Spieler spieler in _SpielerListe)
            {
                spieler.Speicher.ListLegAktuell.Add(spieler.AktuellesLeg);
            }
        }

        public void SetSpeichern()
        {
            foreach (Spieler spieler in _SpielerListe)
            {   
                spieler.Speicher.ListLegAverage.Add(spieler.Speicher.ListLegAktuell);
                spieler.Speicher.ListSetAverage.Add(spieler.AktuellesSet);
                spieler.Speicher.ListLegAktuell = new List<AktuellesLeg>();
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
            _AktuellenSpieler = _SpielerListe[_AktuellerSpielerPos];
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
            _AktuellenSpieler = _SpielerListe[_AktuellerSpielerPos];
        }

        public void SpeichereSpiel(MatchObjekt pMatch)
        {
            SaveGame save = new SaveGame(pMatch);
            foreach (Spieler spieler in _SpielerListe)
            {
                save.NeuerSpieler(spieler);
            }
            save.SchliesseDatei();

        }

        #region Getter/Setter
        public String getName()
        {
            return _AktuellenSpieler.GetName();
        }

        public int getGewonnenLegs()
        {
            return _AktuellenSpieler.Gewonnen.Leg;
        }   

        public int getGewonnenSet()
        {
            return _AktuellenSpieler.Gewonnen.Set;
        }

        public int getAnzahlSechzig()
        {
            return _AktuellenSpieler.Anzahl.Sechzig;
        }

        public int getAnzahlHundert()
        {
            return _AktuellenSpieler.Anzahl.Hundert;
        }

        public int getAnzahlHundertVierzig()
        {
            return _AktuellenSpieler.Anzahl.HundertVierzig;
        }

        public int getAnzahlHundertAchzig()
        {
            return _AktuellenSpieler.Anzahl.HundertAchzig;
        }

        public Double getAverageSpiel()
        {
            return _AktuellenSpieler.GesamtSpiel.Average;
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
            return _AktuellenSpieler.GesamtSpiel.Wuerfe;
        }

        public Double getGesamtPunktzahl()
        {
            return _AktuellenSpieler.GesamtSpiel.PunktZahl;
        }

        public int getPunktestand()
        {
            return _AktuellenSpieler.AktuellePunktZahl;
        }

        public int[] getListHighScore()
        {
            return _AktuellenSpieler.HighScore.Scores;
        }

        public int[] getListHighScoreAnzahl()
        {
            return _AktuellenSpieler.HighScore.AnzahlScore;
        }

        public int[] getListHighFinish()
        {
            return _AktuellenSpieler.HighScore.FinishScore;
        }

        public int[] getListHighFinishAnzahl()
        {
            return _AktuellenSpieler.HighScore.AnzahlFinish;
        }

        public int getAnzahlHundertSiebzig()
        {
            return _AktuellenSpieler.Anzahl.HundertSiebzig;
        }

        public void setAnzahlHundertSiebzig(int pHundertSiebzig)
        {
            _AktuellenSpieler.Anzahl.HundertSiebzig = pHundertSiebzig;
        }

        public void setShortestLeg(double pShortestLeg)
        {
            _AktuellenSpieler.Gewonnen.ShortesLeg = pShortestLeg;
        }

        public void setLongestLeg(double pLongestLeg)
        {
            _AktuellenSpieler.Gewonnen.LongestLeg = pLongestLeg;
        }

        public double getShortestLeg()
        {
            return _AktuellenSpieler.Gewonnen.ShortesLeg;
        }

        public double getLongestLeg()
        {
            return _AktuellenSpieler.Gewonnen.LongestLeg;
        }

        public Speicher getSpeicher()
        {
            return _AktuellenSpieler.Speicher;
        }

        public void setGewonnenLegs(int pLeg)
        {
            _AktuellenSpieler.Gewonnen.Leg = pLeg;
        }

        public void setGewonnenSet(int pSet)
        {
            _AktuellenSpieler.Gewonnen.Set = pSet;
        }

        public void setAnzahlSechzig(int pAnzahlSechzig)
        {
            _AktuellenSpieler.Anzahl.Sechzig = pAnzahlSechzig;
        }

        public void setAnzahlHundert(int pAnzahlHundert)
        {
            _AktuellenSpieler.Anzahl.Hundert = pAnzahlHundert;
        }

        public void setAnzahlHundertVierzig(int pAnzahlHundertVierzig)
        {
            _AktuellenSpieler.Anzahl.HundertVierzig = pAnzahlHundertVierzig;
        }

        public void setAnzahlHundertAchzig(int pAnzahlHundertAchzig)
        {
            _AktuellenSpieler.Anzahl.HundertAchzig = pAnzahlHundertAchzig;
        }

        public void setAverageSpiel(Double pAverageSpiel)
        {
            _AktuellenSpieler.GesamtSpiel.Average = pAverageSpiel;
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
            _AktuellenSpieler.GesamtSpiel.Wuerfe = pWuerfe;
        }

        public void setGesamtPunktzahl(Double pPunktzahl)
        {
            _AktuellenSpieler.GesamtSpiel.PunktZahl = pPunktzahl;
        }

        public void setPunkteStand(int punktestand)
        {
            _AktuellenSpieler.AktuellePunktZahl = punktestand;
        }

        public void setListHighScore(int[] pListHighScore)
        {
            _AktuellenSpieler.HighScore.Scores = pListHighScore;
        }

        public void setListHighScoreAnzahl(int[] pListHighScoreAnzahl)
        {
            _AktuellenSpieler.HighScore.AnzahlScore = pListHighScoreAnzahl;
        }

        public void setListHighFinish(int[] pListHighFinish)
        {
            _AktuellenSpieler.HighScore.FinishScore = pListHighFinish;
        }

        public void setListHighFinishAnzahl(int[] pListHighFinishAnzahl)
        {
            _AktuellenSpieler.HighScore.AnzahlFinish = pListHighFinishAnzahl;
        }

        #endregion
    }
}
