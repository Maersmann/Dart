using Programm.Optionen.Utils;
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
using Programm.Optionen.DataModul;

namespace Programm.Optionen.Frame
{
    /// <summary>
    /// Interaktionslogik für FrameOptionenStatistik.xaml
    /// </summary>
    public partial class FrameOptionenStatistik : Page
    {

        public FrameOptionenStatistik( OptionStatistik inOptionStatistik  )
        {
            InitializeComponent();

            this.DataContext = inOptionStatistik;

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

    }
}
