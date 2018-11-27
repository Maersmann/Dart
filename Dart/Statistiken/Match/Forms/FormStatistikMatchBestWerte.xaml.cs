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
using Dart.MatchViews;
using Dart.MatchViews.Matchobjekte;

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
            public int Score { get; set; }
        }

        public FormStatistikMatchBestWerte(MatchModel pMatchmodel)
        {
             InitializeComponent();
            _matchmodel = pMatchmodel;



            foreach (MatchSpieler spieler in _matchmodel.getSpielerList()) 
            {
                listBoxSpielerList.Items.Add( spieler.Spieler.Spitzname );  
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

            for (int BestScoreDurchlauf = 0; BestScoreDurchlauf < pSpieler.Statistiken.Highfinish.Count() ; BestScoreDurchlauf++)
            {
                SpielerDataBestFinish BestFinish = new SpielerDataBestFinish();
                BestFinish.Anzahl = pSpieler.Statistiken.Highfinish[BestScoreDurchlauf].Anzahl;
                BestFinish.Score = pSpieler.Statistiken.Highfinish[BestScoreDurchlauf].Score;
                listSpielerFinish.Add(BestFinish);
            }
            for (int BestScoreDurchlauf = 0; BestScoreDurchlauf < pSpieler.Statistiken.Highscore.Count(); BestScoreDurchlauf++)
            {
                SpielerDataBestWurf BestWurf = new SpielerDataBestWurf();
                BestWurf.Anzahl = pSpieler.Statistiken.Highscore[BestScoreDurchlauf].Anzahl;
                BestWurf.Score = pSpieler.Statistiken.Highscore[BestScoreDurchlauf].Score;
                listSpielerWurf.Add(BestWurf);
            }


                
            

            dgFinish.ItemsSource = listSpielerFinish;
            dgHighWurf.ItemsSource = listSpielerWurf;
        }




        private void listBoxSpielerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SpielerName = listBoxSpielerList.SelectedItem.ToString();
            foreach (MatchSpieler spieler in _matchmodel.getSpielerList())
            {
                if (spieler.Spieler.Spitzname== SpielerName)
                    ChangeAnsicht(spieler);
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
