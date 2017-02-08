using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Dart.Optionen.Utils;
using Dart.Optionen.DataModul;

namespace Dart.Optionen.Frame
{
    /// <summary>
    /// Interaktionslogik für OptionenMatch.xaml
    /// </summary>
    public partial class FrameOptionenMatch : Page
    {
        private OptionGame _optGame;
        private OptionIni _optIni;

        public FrameOptionenMatch()
        {
            InitializeComponent();

            _optIni = new OptionIni();
            _optGame = _optIni.readIniGame();

            TxtBoxLegZumSet.Text = _optGame.LegZumSet.ToString();
            TxtBoxSetZumSieg.Text = _optGame.SetZumSieg.ToString();
            cBoxPunktzahl.Text = _optGame.Punktzahl.ToString();
        }

        private void TxtBoxLegZumSet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtBoxSetZumSieg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Canvas_Unloaded(object sender, RoutedEventArgs e)
        {
            _optGame.LegZumSet = int.Parse(TxtBoxLegZumSet.Text);
            _optGame.Punktzahl = int.Parse(cBoxPunktzahl.Text);
            _optGame.SetZumSieg = int.Parse(TxtBoxSetZumSieg.Text);
            _optIni.writeIniGame(_optGame);
        }
    }
}
