using Dart.Match.Matchobjekte;
using Dart.SpielerObjekte;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Utils
{
    public class SaveGame
    {
        private String TextInhalt;
        StreamWriter file;

        public SaveGame(MatchObjekt pMatch)
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
            TextInhalt += "Spielvariante : First to " + Convert.ToString(pMatch.SetZumSieg) + "\r\n";

        }

        public void NeuerSpieler(MatchSpieler pSpieler)
        {
            TextInhalt += "\r\n \r\n Name des Spielers: " + pSpieler.Spieler.GetName() + "\r\n";
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

            for (int ScoreDurchlauf = 9; ScoreDurchlauf >= 0; ScoreDurchlauf--)
            {
                if (pSpieler.HighScore.Scores[ScoreDurchlauf] > 0)
                {
                    if (pSpieler.HighScore.AnzahlScore[ScoreDurchlauf] > 0)
                    {
                        TextInhalt += "\t" + pSpieler.HighScore.Scores[ScoreDurchlauf] + "\t" + pSpieler.HighScore.AnzahlScore[ScoreDurchlauf] + "x\r\n";
                    }
                }

            }
            TextInhalt += "\r\n--------Highfinish--------\r\n";

            for (int FinishDurchlauf = 9; FinishDurchlauf >= 0; FinishDurchlauf--)
            {
                if (pSpieler.HighScore.AnzahlFinish[FinishDurchlauf] > 0)
                {
                    if (pSpieler.HighScore.FinishScore[FinishDurchlauf] > 0)
                    {
                        TextInhalt += "\t" + pSpieler.HighScore.FinishScore[FinishDurchlauf] + "\t" + pSpieler.HighScore.AnzahlFinish[FinishDurchlauf] + "x\r\n";
                    }
                }

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
