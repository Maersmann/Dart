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



            foreach (Spieler spieler in _matchmodel.getSpielerList()) 
            {
                listBoxSpielerList.Items.Add( spieler.GetName() );
                ChangeAnsicht(spieler);
            }

        }

        public void ChangeAnsicht(Spieler pSpieler)
        {
            listSpieler.Clear();

            int AktuellesSet = 1;
            foreach (List<AktuellesLeg> LegAverage in pSpieler.Speicher.ListLegAverage)
            {
               // TextInhalt += "\r\n---------- Set " + AktuellesSet + " -----------\r\n\r\n";



                //TextInhalt += "------Average Set:" + spieler.Speicher.ListSetAverage[AktuellesSet - 1].Average + " ------\r\n\r\n";
                int AktuellesLeg = 1;
                foreach (AktuellesLeg Average in LegAverage)
                {
                    SpielerDataAver SpielerData = new SpielerDataAver();
                    SpielerData.Set = AktuellesSet;
                    SpielerData.Leg = AktuellesLeg.ToString();
                    SpielerData.Average = Average.Average;
               
                   // TextInhalt += "Leg: " + Convert.ToString(AktuellesLeg) + "| Average: " + Convert.ToString(Average.Average) + "     \t Würfe: " + Convert.ToString(Average.Wuerfe) + "  Rest: " + Convert.ToString(501 - Average.Punktzahl) + "\r\n";
                    AktuellesLeg++;

                    listSpieler.Add(SpielerData);
                }
                AktuellesSet++;

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
