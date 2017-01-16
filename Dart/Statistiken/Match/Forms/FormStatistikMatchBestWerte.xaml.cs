using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dart.Match;
using Dart.SpielerObjekte;
using Dart.Match.Matchobjekte;

namespace Dart.Statistiken.Match.Forms
{
    /// <summary>
    /// Interaktionslogik für FormStatistikMatchAverage.xaml
    /// </summary>
    public partial class FormStatistikMatchBestWerte : Window
    {
        private MatchModel _matchmodel;
        List<SpielerDataBestWurf> listSpielerWurf;
        List<SpielerDataBestFinish> listSpielerFinish;

        public class SpielerDataBestWurf
        {
            public int Anzahl { get; set; }
            public int Score { get; set; }   
        }

        public class SpielerDataBestFinish
        {
            public int Anzahl { get; set; }
            public int Finish { get; set; }
        }

        public FormStatistikMatchBestWerte(MatchModel pMatchmodel)
        {
             InitializeComponent();
            _matchmodel = pMatchmodel;



            foreach (MatchSpieler spieler in _matchmodel.getSpielerList()) 
            {
                listBoxSpielerList.Items.Add( spieler.Spieler.GetName() );  
            }

            listBoxSpielerList.SelectedIndex = 0;

        }

        public void ChangeAnsicht(MatchSpieler pSpieler)
        {
            listSpielerFinish = new List<SpielerDataBestFinish>();
            listSpielerWurf = new List<SpielerDataBestWurf>();

            LblAnzahl60Text.Content = pSpieler.Statistiken.Sechzig.ToString();
            LblAnzahl100Text.Content = pSpieler.Statistiken.Hundert.ToString();
            LblAnzahl140Text.Content = pSpieler.Statistiken.HundertVierzig.ToString();
            LblAnzahl170Text.Content = pSpieler.Statistiken.HundertSiebzig.ToString();
            LblAnzahl180Text.Content = pSpieler.Statistiken.HundertAchzig.ToString();
            LblLongestLegText.Content = pSpieler.Statistiken.LongestLeg.ToString();
            LblShortestLegText.Content = pSpieler.Statistiken.ShortesLeg.ToString();

            for (int BestScoreDurchlauf = 9; BestScoreDurchlauf >= 0; BestScoreDurchlauf--)
            {
                if (pSpieler.HighScore.AnzahlFinish[BestScoreDurchlauf] > 0 && pSpieler.HighScore.FinishScore[BestScoreDurchlauf] > 0)
                {
                    SpielerDataBestFinish BestFinish = new SpielerDataBestFinish();
                    BestFinish.Anzahl = pSpieler.HighScore.AnzahlFinish[BestScoreDurchlauf];
                    BestFinish.Finish = pSpieler.HighScore.FinishScore[BestScoreDurchlauf];
                    listSpielerFinish.Add(BestFinish);
                }

                if (pSpieler.HighScore.Scores[BestScoreDurchlauf] > 0 && pSpieler.HighScore.AnzahlScore[BestScoreDurchlauf] > 0)
                {

                    SpielerDataBestWurf BestWurf = new SpielerDataBestWurf();
                    BestWurf.Anzahl = pSpieler.HighScore.AnzahlScore[BestScoreDurchlauf];
                    BestWurf.Score = pSpieler.HighScore.Scores[BestScoreDurchlauf];
                    listSpielerWurf.Add(BestWurf);
                }
            }

            dgFinish.ItemsSource = listSpielerFinish;
            dgHighWurf.ItemsSource = listSpielerWurf;
        }




        private void listBoxSpielerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SpielerName = listBoxSpielerList.SelectedItem.ToString();
            foreach (MatchSpieler spieler in _matchmodel.getSpielerList())
            {
                if (spieler.Spieler.GetName() == SpielerName)
                    ChangeAnsicht(spieler);
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
