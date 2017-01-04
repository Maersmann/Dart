using Dart.MatchObjekte;
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

        public void NeuerSpieler(Spieler pSpieler)
        {
            TextInhalt += "\r\n \r\n Name des Spielers: " + pSpieler.GetName() + "\r\n";
            TextInhalt += "_________________________________\r\n";
            TextInhalt += "Gewonnene Sets: " + pSpieler.Gewonnen.Set + "\r\n\r\n";

            int AktuellesSet = 1;
            foreach (List<AktuellesLeg> LegAverage in pSpieler.Speicher.ListLegAverage)
            {
                TextInhalt += "\r\n---------- Set " + AktuellesSet + " -----------\r\n\r\n";

                TextInhalt += "------Average Set:" + pSpieler.Speicher.ListSetAverage[AktuellesSet-1].Average + " ------\r\n\r\n";
                int AktuellesLeg = 1;
                foreach (AktuellesLeg Average in LegAverage)
                {
                    TextInhalt += "Leg: " + Convert.ToString(AktuellesLeg) + "| Average: " + Convert.ToString(Average.Average) + "     \t Würfe: " + Convert.ToString(Average.Wuerfe) + "  Rest: " + Convert.ToString(501- Average.Punktzahl) + "\r\n";
                    AktuellesLeg++;
                }
                AktuellesSet++;
                
            }

            TextInhalt += "\r\n Bestwerte des Games!\r\n";
            TextInhalt += "--------Highscore--------\r\n";

            for (int ScoreDurchlauf = 9; ScoreDurchlauf >= 0; ScoreDurchlauf--)
            {
                if (pSpieler.HighScore.Scores[ScoreDurchlauf] > 0)
                {
                    if (pSpieler.HighScore.Scores[ScoreDurchlauf] > 0)
                    {
                        TextInhalt += "\t" + pSpieler.HighScore.Scores[ScoreDurchlauf] + "\t" + pSpieler.HighScore.AnzahlScore[ScoreDurchlauf] + "x\r\n";
                    }
                }

            }
            TextInhalt += "\r\n--------Highfinish--------\r\n";

            for (int FinishDurchlauf = 9; FinishDurchlauf >= 0; FinishDurchlauf--)
            {
                if (pSpieler.HighScore.Scores[FinishDurchlauf] > 0)
                {
                    if (pSpieler.HighScore.FinishScore[FinishDurchlauf] > 0)
                    {
                        TextInhalt += "\t" + pSpieler.HighScore.FinishScore[FinishDurchlauf] + "\t" + pSpieler.HighScore.AnzahlFinish[FinishDurchlauf] + "x\r\n";
                    }
                }

            }

            TextInhalt += "\r\n60>: " + pSpieler.Anzahl.Sechzig;
            TextInhalt += "\r\n100>: " + pSpieler.Anzahl.Hundert;
            TextInhalt += "\r\n140>: " + pSpieler.Anzahl.HundertVierzig;
            TextInhalt += "\r\n180: " + pSpieler.Anzahl.HundertAchzig;

            TextInhalt += "\r\nEndAverage lautet: " + pSpieler.GesamtSpiel.Average + "\r\n";
            TextInhalt += "\r\n################################################\r\n\r\n\r\n";
          
        }

        public void SchliesseDatei()
        {
            file.WriteLine(TextInhalt);
            file.Close();
        }
    }
}
