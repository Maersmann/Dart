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
                _formMatch = new FormMatch();

            Container.NavigationService.Navigate(_formMatch);
        }

        private void rbMatchUndo_Click(object sender, RoutedEventArgs e)
        {
            _formMatch.doRueckgaengig();
        }

        private void rbMatchRedo_Click(object sender, RoutedEventArgs e)
        {
            _formMatch.doWiederholen();
        }

        private void rbMatchNewGame_Click(object sender, RoutedEventArgs e)
        {
            FormSpielerAuswahl formSpielerAuswahl = new FormSpielerAuswahl( _formMatch );
            formSpielerAuswahl.ShowDialog();
        }

        private void Container_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content == _formMatch)
            {
                ribboncontextMatch.Visibility = Visibility.Visible;
            }
            else
                ribboncontextMatch.Visibility = Visibility.Hidden;
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {

        }
    }
}
