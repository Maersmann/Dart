using Dart.SpielerObjekte;
using System;
using System.Collections.Generic;

namespace Dart
{
    public class Spieler
    {
        private String Name;

        public int AktuellePunktZahl { get; set; }

        public HighScore HighScore;
        public AnzahlScore Anzahl;
        public Gewonnen Gewonnen;
        public GesamtSpiel GesamtSpiel;
        public AktuellesLeg AktuellesLeg;
        public AktuellesSet AktuellesSet;
        public Speicher Speicher;


        public Spieler(String inName)
        {
            Name = inName;
            AktuellePunktZahl = 501;
            HighScore = new HighScore();
            Anzahl = new AnzahlScore();
            GesamtSpiel = new GesamtSpiel();
            AktuellesLeg = new AktuellesLeg();
            Gewonnen = new Gewonnen();
            AktuellesSet = new AktuellesSet();
            Speicher = new Speicher();

        }

        public String GetName()
        {
            return Name;
        }

        public Spieler getSpielerMemento()
        {
            Spieler memento = new Spieler(Name);
            memento.Gewonnen.Leg = this.Gewonnen.Leg;
            memento.Gewonnen.LongestLeg = this.Gewonnen.LongestLeg;
            memento.Gewonnen.Set = this.Gewonnen.Set;
            memento.Gewonnen.ShortesLeg = this.Gewonnen.ShortesLeg;
            memento.AktuellesLeg.Average = this.AktuellesLeg.Average;
            memento.AktuellesLeg.Punktzahl = this.AktuellesLeg.Punktzahl;
            memento.AktuellesLeg.Wuerfe = this.AktuellesLeg.Wuerfe;
            memento.AktuellesSet.Average = this.AktuellesSet.Average;
            memento.AktuellesSet.Punktzahl = this.AktuellesSet.Punktzahl;
            memento.AktuellesSet.Wuerfe = this.AktuellesSet.Wuerfe;
            memento.Anzahl.Hundert = this.Anzahl.Hundert;
            memento.Anzahl.HundertAchzig = this.Anzahl.HundertAchzig;
            memento.Anzahl.HundertSiebzig = this.Anzahl.HundertSiebzig;
            memento.Anzahl.HundertVierzig = this.Anzahl.HundertVierzig;
            memento.Anzahl.Sechzig = this.Anzahl.Sechzig;
            memento.GesamtSpiel.Average = this.GesamtSpiel.Average;
            memento.GesamtSpiel.PunktZahl = this.GesamtSpiel.PunktZahl;
            memento.GesamtSpiel.Wuerfe = this.GesamtSpiel.Wuerfe;
            memento.HighScore.AnzahlFinish = this.HighScore.AnzahlFinish;
            memento.HighScore.AnzahlScore = this.HighScore.AnzahlScore;
            memento.HighScore.FinishScore = this.HighScore.FinishScore;
            memento.HighScore.Scores = this.HighScore.Scores;
            memento.Speicher.ListLegAktuell = new List<AktuellesLeg>(this.Speicher.ListLegAktuell);
            memento.Speicher.ListLegAverage = new List<List<AktuellesLeg>>(this.Speicher.ListLegAverage);
            memento.Speicher.ListSetAverage = new List<AktuellesSet>(this.Speicher.ListSetAverage);
            memento.AktuellePunktZahl = this.AktuellePunktZahl;
            return memento;
        }
    }
}
