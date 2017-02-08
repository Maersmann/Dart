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

        OptionenMatch _OptionenMatch;

        public FormOptionen()
        {
            InitializeComponent();

            _OptionenMatch = new OptionenMatch();
            frameOptionen.Navigate(_OptionenMatch);
        }
    }
}
