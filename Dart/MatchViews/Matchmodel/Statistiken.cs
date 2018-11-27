using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dart.MatchViews.Matchobjekte
{
    public class Statistiken
    {
        public int Sechzig { get; set; }
        public int Hundert { get; set; }
        public int HundertVierzig { get; set; }
        public int HundertAchzig { get; set; }
        public int HundertSiebzig { get; set; }
        public double ShortesLeg { get; set; }
        public double LongestLeg { get; set; }
        public List<Wert> Highfinish { get; set; }
        public List<Wert> Highscore { get; set; }

        public Statistiken()
        {
            Sechzig = 0;
            Hundert = 0;
            HundertVierzig = 0;
            HundertAchzig = 0;
            HundertSiebzig = 0;

            ShortesLeg = 0;
            LongestLeg = 0;
            Highfinish = new List<Wert>();
            Highscore = new List<Wert>();
        }

        public Statistiken getMemento()
        {
            Statistiken memento = new Statistiken();
            for (int mementoLaeufer = 0; mementoLaeufer < this.Highscore.Count(); mementoLaeufer++)
            {
                memento.Highscore.Add( this.Highscore[mementoLaeufer] );
            }
            for (int mementoLaeufer = 0; mementoLaeufer < this.Highfinish.Count(); mementoLaeufer++)
            {
                memento.Highfinish.Add ( this.Highfinish[mementoLaeufer] ) ;
            }
            memento.Hundert = this.Hundert;
            memento.HundertAchzig = this.HundertAchzig;
            memento.HundertSiebzig = this.HundertSiebzig;
            memento.HundertVierzig = this.HundertVierzig;
            memento.LongestLeg = this.LongestLeg;
            memento.Sechzig = this.Sechzig;
            memento.ShortesLeg = this.ShortesLeg;
            return memento;
        }

    }

    public class Wert
    {
        public int Anzahl;
        public int Score;

        public Wert()
        {
            Anzahl = 0;
            Score = 0;
        }
    }
}
