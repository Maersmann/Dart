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
    public partial class FormStatistikMatchAverage : Window
    {
        private MatchModel _matchmodel;
        List<SpielerDataAver> listSpieler;

        public FormStatistikMatchAverage(MatchModel pMatchmodel)
        {
            listSpieler = new List<SpielerDataAver>();
            

            InitializeComponent();
            _matchmodel = pMatchmodel;



            foreach (MatchSpieler spieler in _matchmodel.getSpielerList()) 
            {
                listBoxSpielerList.Items.Add( spieler.Spieler.GetName() );
                ChangeAnsicht(spieler);
            }

        }

        public void ChangeAnsicht(MatchSpieler pSpieler)
        {
            listSpieler.Clear();


            foreach (Set Set in pSpieler.Sets)
            {
                SpielerDataAver SpielerData = new SpielerDataAver();
                SpielerData.Set = Set.Nummer;

                foreach (Leg Average in Set.Legs)
                {
                    SpielerData.Leg = Average.Nummer.ToString();
                    SpielerData.Average = Average.Average;
                    listSpieler.Add(SpielerData);
                }
            }


            dataGrid.ItemsSource = listSpieler;

        }

        public class SpielerDataAver
        {
            public String Leg { get; set; }
            public int Set { get; set; }
            public Double Average { get; set; }
        }
    }
}
