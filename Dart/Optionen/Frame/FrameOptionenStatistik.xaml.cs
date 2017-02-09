using Dart.Optionen.Utils;
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
using Dart.Optionen.DataModul;

namespace Dart.Optionen.Frame
{
    /// <summary>
    /// Interaktionslogik für FrameOptionenStatistik.xaml
    /// </summary>
    public partial class FrameOptionenStatistik : Page
    {

        OptionStatistik _OptionStatistik;
        public FrameOptionenStatistik( OptionStatistik inOptionStatistik  )
        {
            InitializeComponent();
            _OptionStatistik = inOptionStatistik;

            TxtBoxSizeScore.Text = _OptionStatistik.HighscoreListSize.ToString();
            TxtBoxSizeFinish.Text = _OptionStatistik.HighfinishListSize.ToString();
        }

        private void TxtBoxSizeScore_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtBoxSizeFinish_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _OptionStatistik.HighscoreListSize = int.Parse(TxtBoxSizeScore.Text);
            _OptionStatistik.HighfinishListSize = int.Parse(TxtBoxSizeFinish.Text);
            
        }
    }
}
