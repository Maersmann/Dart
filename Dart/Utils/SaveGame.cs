using Dart.MatchViews.Matchobjekte;
using System;
using System.IO;
using System.Linq;
using Repository.MatchEntity;

namespace Dart.Utils
{
    public class SaveGame
    {
        private String TextInhalt;
        StreamWriter file;

        public SaveGame(Match pMatch)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Dart Ergebnisse";
            DirectoryInfo DI = new DirectoryInfo(path);
            if (!DI.Exists)
            {
                string pathString = System.IO.Path.Combine(path);
                System.IO.Directory.CreateDirectory(pathString);
            }


            String filename = DateTime.Now.ToString("dd-MMM-yyyy_HH-mm") + ".txt";
            file = new System.IO.StreamWriter(path + "/" + filename);
            file.Flush();
            TextInhalt = "Auswertung des Games!!!\r\n";

            TextInhalt += "##########################\r\n";
            TextInhalt += "Ergebnis der Spiels\r\n";
            TextInhalt += "_________________________\r\n\r\n";
            
            if (pMatch.SetZumSieg > 1)
            { 
                TextInhalt += "Spielvariante : First to " + Convert.ToString(pMatch.SetZumSieg) + " Sets\r\n";
                TextInhalt += Convert.ToString(pMatch.LegZumSet) + " Leg(s) für Setgewinn" + "\r\n";
            }
            else
                TextInhalt += "Spielvariante : First to " + Convert.ToString(pMatch.LegZumSet) + " Legs\r\n";

            TextInhalt += "Punkzahl: " + Convert.ToString(pMatch.PunktZahlzumLeg) + "\r\n";
        }

        public void NeuerSpieler(MatchSpieler pSpieler )
        {
            TextInhalt += "\r\n \r\n Name des Spielers: " + pSpieler.Spieler.Spitzname + "\r\n";
            TextInhalt += "_________________________________\r\n";
            TextInhalt += "Gewonnene Sets: " + pSpieler.AnzahlSetGewonnen + "\r\n\r\n";

            foreach (Set Set in pSpieler.Sets)
            {
                TextInhalt += "\r\n---------- Set " + Set.Nummer + " -----------\r\n\r\n";

                TextInhalt += "------Average Set:" + Set.Average + " ------\r\n\r\n";
                foreach (Leg Average in Set.Legs)
                {
                    TextInhalt += "Leg: " + Average.Nummer + "| Average: " + Average.Average + "     \t Würfe: " + Average.Wuerfe + "  Rest: " + Convert.ToString(501- Average.Punktzahl) + "\r\n";
                }     
            }

            TextInhalt += "\r\n Bestwerte des Games!\r\n";
            TextInhalt += "--------Highscore--------\r\n";

            for (int ListIndex = 0; ListIndex < pSpieler.Statistiken.Highscore.Count(); ListIndex++)
            {
                TextInhalt += "\t" + pSpieler.Statistiken.Highscore[ListIndex].Score + "\t" + pSpieler.Statistiken.Highscore[ListIndex].Anzahl + "x\r\n";
            }
            TextInhalt += "\r\n--------Highfinish--------\r\n";

            for (int ListIndex = 0; ListIndex < pSpieler.Statistiken.Highfinish.Count(); ListIndex++)
            {
                TextInhalt += "\t" + pSpieler.Statistiken.Highfinish[ListIndex].Score+ "\t" + pSpieler.Statistiken.Highfinish[ListIndex].Anzahl + "x\r\n";
            }

            TextInhalt += "\r\n60>: " + pSpieler.Statistiken.Sechzig;
            TextInhalt += "\r\n100>: " + pSpieler.Statistiken.Hundert;
            TextInhalt += "\r\n140>: " + pSpieler.Statistiken.HundertVierzig;
            TextInhalt += "\r\n170: " + pSpieler.Statistiken.HundertSiebzig;
            TextInhalt += "\r\n180: " + pSpieler.Statistiken.HundertAchzig;
            TextInhalt += "\r\nShortest Leg: " + pSpieler.Statistiken.ShortesLeg;
            TextInhalt += "\r\nLongest Leg: " + pSpieler.Statistiken.LongestLeg;

            TextInhalt += "\r\n\r\nEndAverage lautet: " + pSpieler.AverageMatch + "\r\n";
            TextInhalt += "\r\n################################################\r\n\r\n\r\n";
          
        }

        public void SchliesseDatei()
        {
            file.WriteLine(TextInhalt);
            file.Close();
        }
    }
}
