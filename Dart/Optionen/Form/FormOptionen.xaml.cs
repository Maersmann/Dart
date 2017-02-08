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

namespace Dart.Optionen.Form
{
    /// <summary>
    /// Interaktionslogik für Optionen.xaml
    /// </summary>
    public partial class FormOptionen : Window
    {

        FrameOptionenMatch _OptionenMatch;

        public FormOptionen()
        {
            InitializeComponent();

            _OptionenMatch = new FrameOptionenMatch();
            frameOptionen.Navigate(_OptionenMatch);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            //Save
            Close();
        }

        private void listBoxOptionen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string FrameOptionen = listBoxOptionen.SelectedItem.ToString();

            if (FrameOptionen == lstBoxItemGame.Content.ToString())
            {
                if (_OptionenMatch == null)
                    _OptionenMatch = new FrameOptionenMatch();
                frameOptionen.Navigate(_OptionenMatch);
            }

            
        }
    }
}
