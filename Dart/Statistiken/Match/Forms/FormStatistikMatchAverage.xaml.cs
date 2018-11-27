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
    public partial class FormStatistikMatchAverage : Window
    {
        private MatchModel _matchmodel;
        List<SpielerDataAver> listSpieler;

        public class SpielerDataAver
        {
            public int Set { get; set; }
            public String Leg { get; set; }
            public Double Average { get; set; }
        }

        public FormStatistikMatchAverage(MatchModel pMatchmodel)
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

            listSpieler = new List<SpielerDataAver>();
            listSpieler.Clear();
            SpielerDataAver SpielerData;

            foreach (Set Set in pSpieler.Sets)
            {
                SpielerData = new SpielerDataAver();
                SpielerData.Set = Set.Nummer;
                SpielerData.Leg = "Average";
                SpielerData.Average = Set.Average;
                listSpieler.Add(SpielerData);

                foreach (Leg Leg in Set.Legs)
                {
                    SpielerData = new SpielerDataAver();
                    SpielerData.Set = Set.Nummer;
                    SpielerData.Leg = Leg.Nummer.ToString();
                    SpielerData.Average = Leg.Average;
                    listSpieler.Add(SpielerData);
                }
            }

            if (_matchmodel.Spielbeendet)
            {
                dataGrid.ItemsSource = listSpieler;
                return;
            }

            Set AktSet = pSpieler.AktuellesSet;
            foreach (Leg AktLeg in AktSet.Legs)
            {
                SpielerData = new SpielerDataAver();
                SpielerData.Set = AktSet.Nummer;
                SpielerData.Leg = AktLeg.Nummer.ToString();
                SpielerData.Average = AktLeg.Average;
                listSpieler.Add(SpielerData);
            }

            SpielerData = new SpielerDataAver();
            SpielerData.Set = AktSet.Nummer;
            SpielerData.Leg = pSpieler.AktuellesLeg.Nummer.ToString();
            SpielerData.Average = pSpieler.AktuellesLeg.Average;
            listSpieler.Add(SpielerData);

            dataGrid.ItemsSource = listSpieler;

        }




        private void listBoxSpielerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string SpielerName = listBoxSpielerList.SelectedItem.ToString();
            foreach (MatchSpieler spieler in _matchmodel.getSpielerList())
            {
                if (spieler.Spieler.Spitzname == SpielerName)
                    ChangeAnsicht(spieler);
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
