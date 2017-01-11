using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Dart.Match.Forms;
using Microsoft.Windows.Controls.Ribbon;

namespace Dart
{
    /// <summary>
    /// Interaktionslogik für Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        private FormMatch _formMatch;
        private StartBildschirm _startBildschirm; 

        public Main()
        {
            InitializeComponent();
            if (_startBildschirm == null)
                _startBildschirm = new StartBildschirm();

            Container.NavigationService.Navigate(_startBildschirm);
        }

        private void rbMatch_Click(object sender, RoutedEventArgs e)
        {
            if (_formMatch == null)
            {
                _formMatch = new FormMatch( this );
                rbMatchRedo.IsEnabled = false;
                rbMatchUndo.IsEnabled = false;
                rbStatistikMatchAverage.IsEnabled = false;
            }

            Container.NavigationService.Navigate(_formMatch);
        }


        private void rbMatchNewGame_Click(object sender, RoutedEventArgs e)
        {

            FormSpielerAuswahl formSpielerAuswahl = new FormSpielerAuswahl( _formMatch );
            bool?  DialogResult   =  formSpielerAuswahl.ShowDialog();

            if (DialogResult == true)
            {
                rbStatistikMatchAverage.IsEnabled = true;

                rbStatistikMatchAverage.Click += _formMatch.rbStatistikMatchAverage_Click;
                rbMatchUndo.Click += _formMatch.rbMatchUndo_Click;
                rbMatchRedo.Click += _formMatch.rbMatchRedo_Click;
            }
                
        }

        private void Container_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content == _formMatch)
            {
                ribboncontextMatch.Visibility = Visibility.Visible;
                ribbonMatch.IsSelected = true;
            }
            else
                ribboncontextMatch.Visibility = Visibility.Hidden;
        }


        private void ribbonMenuClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
