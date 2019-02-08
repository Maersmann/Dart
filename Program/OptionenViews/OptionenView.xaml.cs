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
using UILogic;

namespace Programm.OptionenViews
{
    /// <summary>
    /// Interaktionslogik für Optionen.xaml
    /// </summary>
    public partial class OptionenView : Window, IClosable
    {


        public OptionenView()
        {
            InitializeComponent();

            listBoxOptionen.Items.Add("Game");
            listBoxOptionen.SelectedIndex = 0;

        }

    }
}
