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

namespace Programm.MatchUtils
{
    /// <summary>
    /// Interaktionslogik für FormDialogFinish.xaml
    /// </summary>
    public partial class FormDialogFinish : Window
    {
        int _AnzahlWuerfe;

        public FormDialogFinish()
        {
            InitializeComponent();
            txtAnzahlWuerfe.Focus();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Weiter();
        }

        public int getAnzahl() { return _AnzahlWuerfe; }

        private void txtAnzahlWuerfe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Weiter();
                return;

            }
        }

        private void Weiter()
        {
            if (!int.TryParse(txtAnzahlWuerfe.Text, out _AnzahlWuerfe))
            {
                MessageBox.Show("Falsche Eingabe");
                return;
            }
            if (_AnzahlWuerfe < 1 || _AnzahlWuerfe > 3)
            {
                MessageBox.Show("Falsche Eingabe");
                return;
            }
            else
            {
                DialogResult = true;
            }
        }

        private void BtnUeberworfen_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            return;
        }
    }
}
