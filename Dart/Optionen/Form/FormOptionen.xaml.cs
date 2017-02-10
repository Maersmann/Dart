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
using System.Windows.Shapes;
using Dart.Optionen.Frame;
using Dart.Optionen.Utils;

namespace Dart.Optionen.Form
{
    /// <summary>
    /// Interaktionslogik für Optionen.xaml
    /// </summary>
    public partial class FormOptionen : Window
    {

        FrameOptionenMatch _OptionenMatch;
        FrameOptionenStatistik _OptionStatistik;
        OptionIni _OptIni;

        public FormOptionen()
        {
            InitializeComponent();
            _OptIni = new OptionIni();

            listBoxOptionen.Items.Add("Game");
            listBoxOptionen.Items.Add("Statistik");
            listBoxOptionen.SelectedIndex = 0;

        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            _OptIni.WriteIni();
            Close();
            
        }

        private void listBoxOptionen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string FrameOptionen = listBoxOptionen.SelectedItem.ToString();

            if (FrameOptionen == "Game")
            {
                if (_OptionenMatch == null)
                    _OptionenMatch = new FrameOptionenMatch(_OptIni.OptionGame);
                frameOptionen.Navigate(_OptionenMatch);
            }
            else if (FrameOptionen == "Statistik")
            {
                if (_OptionStatistik == null)
                    _OptionStatistik = new FrameOptionenStatistik(_OptIni.OptionStatistik);
                frameOptionen.Navigate(_OptionStatistik);
            }


        }

        private void frameOptionen_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
