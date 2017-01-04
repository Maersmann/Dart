using Dart.MatchObjekte;
using Dart.MatchUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace Dart.Match
{
    public class MatchController
    {
        public MatchModel _Matchmodel { private get; set; }
        MatchObjekt _Match;
        public Boolean SpielBeendet { get; set; }

        public MatchController(MatchModel pMatchModel, MatchObjekt pMatch )
        {
            _Matchmodel = pMatchModel;
            _Match = pMatch;
            SpielBeendet = false;
        }

        


        public Boolean isFinishBereich()
        {
            return  (_Matchmodel.getPunktestand() != 169 &&
                     _Matchmodel.getPunktestand() != 168 &&
                     _Matchmodel.getPunktestand() != 166 &&
                     _Matchmodel.getPunktestand() != 165 &&
                     _Matchmodel.getPunktestand() != 163 &&
                     _Matchmodel.getPunktestand() != 162 &&
                     _Matchmodel.getPunktestand() != 159 &&
                     _Matchmodel.getPunktestand() <= 170);

        }


        public void WurfBerechnen(int pWurf1, int pWurf2, int pWurf3)
        {
            int WurfGesamt = pWurf1 +pWurf2 + pWurf3;
           
            
            if (!CheckPunktzahl(WurfGesamt))
            {
                
                AverageBerechnen(3, 0);
                _Matchmodel.NaechsterSpieler();
            }
            else if (CheckLegGewonnen(WurfGesamt)) 
            {
                

                FormDialogFinish dialog = new FormDialogFinish();
                if (dialog.ShowDialog()  == true)
                {
                    HighScoreCheck(WurfGesamt, true);
                    AverageBerechnen(dialog.getAnzahl(), WurfGesamt);
                    SpielGewonnen();
                }
                else
                {
                    AverageBerechnen(3, 0);
                    _Matchmodel.NaechsterSpieler();
                }
                dialog.Close();
        
                
            }
            else
            {
                AverageBerechnen(3, WurfGesamt);
                HighScoreCheck(WurfGesamt);
                _Matchmodel.setPunkteStand(_Matchmodel.getPunktestand() - WurfGesamt);
                _Matchmodel.NaechsterSpieler();
            }        
        }

        private void AverageBerechnen(int pWuerfe, int pPunktzahl)
        {
            AverageBerechnen average;

            average = new AverageBerechnen(pWuerfe, pPunktzahl, _Matchmodel.getLegWuerfe(), _Matchmodel.getLegPunktzahl());
            _Matchmodel.setAverageLeg(average.getAverage());
            _Matchmodel.setLegWuerfe(average.getWuerfe());
            _Matchmodel.setLegPunktzahl(average.getPunktzahl());

            average = new AverageBerechnen(pWuerfe, pPunktzahl, _Matchmodel.getSetWuerfe(), _Matchmodel.getSetPunktzahl());
            _Matchmodel.setAverageSet(average.getAverage());
            _Matchmodel.setSetWuerfe(average.getWuerfe());
            _Matchmodel.setSetPunktzahl(average.getPunktzahl());

            average = new AverageBerechnen(pWuerfe, pPunktzahl, _Matchmodel.getGeamtWuerfe(), _Matchmodel.getGesamtPunktzahl());
            _Matchmodel.setAverageSpiel(average.getAverage());
            _Matchmodel.setGesamtWuerfe(average.getWuerfe());
            _Matchmodel.setGesamtPunktzahl(average.getPunktzahl());
        }

        private void HighScoreCheck(int pWuerfe, Boolean isFinish = false)
        {
            if (isFinish)
            {
                HighFinishCheck highfinish = new HighFinishCheck(_Matchmodel.getListHighFinish(), _Matchmodel.getListHighFinishAnzahl(), pWuerfe);
                _Matchmodel.setListHighFinish(highfinish.getListHighFinish());
                _Matchmodel.setListHighFinishAnzahl(highfinish.getListAnzahl());
            }
            

            HighScoreCheck highscore = new HighScoreCheck(_Matchmodel.getListHighScore(), _Matchmodel.getListHighScoreAnzahl(), pWuerfe);
            _Matchmodel.setListHighScore(highscore.getListHighScore());
            _Matchmodel.setListHighScoreAnzahl(highscore.getListAnzahl());

            AnzahlScoreCheck AnzahlScore = new AnzahlScoreCheck(_Matchmodel.getAnzahlSechzig(), _Matchmodel.getAnzahlHundert(), _Matchmodel.getAnzahlHundertVierzig(), _Matchmodel.getAnzahlHundertAchzig(), _Matchmodel.getAnzahlHundertSiebzig(), pWuerfe);
            _Matchmodel.setAnzahlHundert(AnzahlScore.getAnzahlHundert());
            _Matchmodel.setAnzahlSechzig(AnzahlScore.getAnzahlSechzig());
            _Matchmodel.setAnzahlHundertAchzig(AnzahlScore.getAnzahlHundertAchtzig());
            _Matchmodel.setAnzahlHundertVierzig(AnzahlScore.getAnzahlHundertVierzig());
            _Matchmodel.setAnzahlHundertSiebzig(AnzahlScore.getAnzahlHundertSiebzig());
        }

        private Boolean CheckPunktzahl(int pWurf)
        {
            
            if (_Matchmodel.getPunktestand() < pWurf || (_Matchmodel.getPunktestand() - pWurf) == 1 || (_Matchmodel.getPunktestand() == pWurf && pWurf > 170 ))
            {
                MessageBox.Show("Überworfen");
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean CheckLegGewonnen(int pWurf)
        {
            return (_Matchmodel.getPunktestand() == pWurf) ;
        }
        
        private void CheckLegLength()
        {
            if (_Matchmodel.getLongestLeg() == 0 || _Matchmodel.getLongestLeg() < _Matchmodel.getLegWuerfe())            
            {
                _Matchmodel.setLongestLeg(_Matchmodel.getLegWuerfe());
            }

            if (_Matchmodel.getShortestLeg() == 0 || _Matchmodel.getShortestLeg() > _Matchmodel.getLegWuerfe())
            {
                _Matchmodel.setShortestLeg(_Matchmodel.getLegWuerfe());
            }
        }

        private void SpielGewonnen()
        {
            _Matchmodel.setGewonnenLegs(_Matchmodel.getGewonnenLegs() + 1);

            CheckLegLength();

            _Matchmodel.LegSpeichern();
            _Matchmodel.LegZurueckSetzen();
            _Matchmodel.PunktzahlZurueckSetzen();

            if (_Matchmodel.getGewonnenLegs()  == _Match.LegZumSet)
            {
                _Matchmodel.setGewonnenSet(_Matchmodel.getGewonnenSet() + 1);

                _Matchmodel.SetSpeichern();
                _Matchmodel.SetZurueckSetzen();
                
                if (_Matchmodel.getGewonnenSet() == _Match.SetZumSieg)
                {
                    MessageBox.Show(_Matchmodel.getName() + " hat das Spiel gewonnen");
                    _Matchmodel.SpeichereSpiel(_Match);
                    SpielBeendet = true;
                    
                }
                else
                {
                    MessageBox.Show(_Matchmodel.getName() + " hat das Set gewonnen");
                    _Matchmodel.SetSpielerNachSet();
                    

                }

                
            }
            else
            {
                _Matchmodel.PunktzahlZurueckSetzen();
                MessageBox.Show(_Matchmodel.getName() + " hat das Leg gewonnen");
                _Matchmodel.SetSpielerNachLeg();
            }
        }
        



    }
}
