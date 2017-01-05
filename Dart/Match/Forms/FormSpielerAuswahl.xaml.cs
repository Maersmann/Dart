using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Dart.Match;
using Dart.MatchObjekte;


namespace Dart.Match.Forms
{
    /// <summary>
    /// Interaktionslogik für FormSpielerAuswahl.xaml
    /// </summary>
    public partial class FormSpielerAuswahl : Window
    {

        FormMatch _formMatch;

        public FormSpielerAuswahl( FormMatch pFormMatch )
        {
            InitializeComponent();
            _formMatch = pFormMatch;
        }

        private void btnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
             
            if (txtNeuerSpieler.Text.Equals(""))
            {
                MessageBox.Show("Kein Name vorhanden!");
                return;
            }

            lstBoxSpieler.Items.Add(txtNeuerSpieler.Text);

            txtNeuerSpieler.Text = "";
            txtNeuerSpieler.Focus();

        }

        private void lstBoxSpieler_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //name ändern
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            int result;
            List<Spieler> ListSpieler = new List<Spieler>();

            if (lstBoxSpieler.Items.Count == 0)
            {
                MessageBox.Show("Keine Spieler vorhanden!");
                return;
            }

            if (txtAnzahlLeg.Text.Equals("") ||  !int.TryParse(txtAnzahlLeg.Text, out result))
            {
                txtAnzahlLeg.Clear();
                MessageBox.Show("Die Legs fehlen!");
                return;
            }

            if (TxtAnzahlSet.Text.Equals("") || !int.TryParse(TxtAnzahlSet.Text, out result))
            {
                TxtAnzahlSet.Clear();
                MessageBox.Show("Die Sets fehlen!");
                return;
            }
   

            foreach (String Name in lstBoxSpieler.Items)
            {
                ListSpieler.Add(new Spieler(Name));
            }

            MatchObjekt match = new MatchObjekt(Convert.ToInt32(TxtAnzahlSet.Text), Convert.ToInt32(txtAnzahlLeg.Text), 501);

            MatchModel matchmodel = new MatchModel(ListSpieler);
            MatchController matchController = new MatchController(matchmodel, match);

            _formMatch.NewGame(matchmodel, matchController);
            this.Close();


        }
    }
}
