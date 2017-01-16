using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dart.SpielerObjekte;

namespace Dart.Match.Matchobjekte
{
    public class MatchSpieler
    {
        public Spieler Spieler { get;  }
        public List<Set> Sets { get; set; }
        public int AktuellePunktZahl { get; set; }
        public HighScore HighScore { get; }
        public Statistiken Statistiken;
        public int AnzahlLegGewonnen { set; get; }
        public int AnzahlSetGewonnen { set; get; }
        public Double WuerfeMatch { get; set; }
        public Double PunktzahlMatch { get; set; }
        public Double AverageMatch { get; set; }
        public Set AktuellesSet { get; set; }
        public Leg AktuellesLeg { get; set; }

        public MatchSpieler ( String pName )
        {
            Spieler = new Spieler( pName );
            HighScore = new HighScore();
            Statistiken = new Statistiken();
            AktuellesSet = new Set();
            AktuellesLeg = new Leg();
            Sets = new List<Set>();
            AnzahlLegGewonnen = 0;
            AnzahlSetGewonnen = 0;
            AktuellePunktZahl = 0;
            WuerfeMatch = 0;
            PunktzahlMatch = 0;
            AverageMatch = 0;
        }

        public MatchSpieler getMatchSpielerMemento()
        {
            MatchSpieler memento = new MatchSpieler( Spieler.GetName() );
            memento.AktuellePunktZahl = this.AktuellePunktZahl;
            memento.AktuellesLeg.Average = this.AktuellesLeg.Average;
            memento.AktuellesLeg.Nummer = this.AktuellesLeg.Nummer;
            memento.AktuellesLeg.Wuerfe = this.AktuellesLeg.Wuerfe;
            memento.AktuellesLeg.Punktzahl = this.AktuellesLeg.Punktzahl;
            memento.AktuellesSet.Average = this.AktuellesSet.Average;
            memento.AktuellesSet.Nummer = this.AktuellesSet.Nummer;
            memento.AktuellesSet.Wuerfe = this.AktuellesSet.Wuerfe;
            memento.AktuellesSet.Punktzahl = this.AktuellesSet.Punktzahl;
            memento.AnzahlLegGewonnen = this.AnzahlLegGewonnen;
            memento.AnzahlSetGewonnen = this.AnzahlSetGewonnen;
            memento.Statistiken.Hundert = this.Statistiken.Hundert;
            memento.Statistiken.Hundert = this.Statistiken.Hundert;
            memento.Statistiken.HundertAchzig = this.Statistiken.HundertAchzig;
            memento.Statistiken.HundertSiebzig = this.Statistiken.HundertSiebzig;
            memento.Statistiken.HundertVierzig = this.Statistiken.HundertVierzig;
            memento.Statistiken.Sechzig = this.Statistiken.Sechzig;
            memento.Statistiken.LongestLeg = this.Statistiken.LongestLeg;
            memento.Statistiken.ShortesLeg = this.Statistiken.ShortesLeg;
            memento.HighScore.AnzahlFinish = this.HighScore.AnzahlFinish;
            memento.HighScore.AnzahlScore = this.HighScore.AnzahlScore;
            memento.HighScore.FinishScore = this.HighScore.FinishScore;
            memento.HighScore.Scores = this.HighScore.Scores;
            memento.PunktzahlMatch = this.PunktzahlMatch;
            memento.WuerfeMatch = this.WuerfeMatch;
            memento.AverageMatch = this.AverageMatch;

            foreach ( Set set in Sets )
            {
                Set setMem = new Set();
                setMem.Nummer = set.Nummer;
                setMem.Average = set.Average;
                setMem.Wuerfe = set.Wuerfe;
                setMem.Punktzahl = set.Punktzahl;

                foreach(Leg leg in set.Legs)
                {
                    Leg legMem = new Leg();
                    legMem.Average = leg.Average;
                    legMem.Wuerfe = leg.Wuerfe;
                    legMem.Punktzahl = leg.Punktzahl;
                    legMem.Nummer = leg.Nummer;
                    setMem.Legs.Add(legMem);
                }
                memento.Sets.Add(set);
            }

            foreach (Leg leg in this.AktuellesSet.Legs)
            {
                Leg legmem = new Leg();
                legmem.Average = leg.Average;
                legmem.Wuerfe = leg.Wuerfe;
                legmem.Punktzahl = leg.Punktzahl;
                legmem.Nummer = leg.Nummer;
                memento.AktuellesSet.Legs.Add(legmem);
            }

            return memento;
        }

    }

    }
