using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Dart.Match.Matchobjekte;


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
            cBoxPunktzahl.SelectedIndex = 0;
        }

        private void btnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            if(lstBoxSpieler.Items.Count >= 8)
            {
                MessageBox.Show("Es sind nur 8 Spieler maximal möglich");
                return;
            }

            if (txtNeuerSpieler.Text.Equals(""))
            {
                MessageBox.Show("Kein Name vorhanden!");
                return;
            }

            lstBoxSpieler.Items.Add(txtNeuerSpieler.Text);

            txtNeuerSpieler.Text = "";
            txtNeuerSpieler.Focus();

        }


        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            int result;
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

            DialogResult = true;

            MatchObjekt match = new MatchObjekt();
            match.LegZumSet = Convert.ToInt32(txtAnzahlLeg.Text);
            match.SetZumSieg = Convert.ToInt32(TxtAnzahlSet.Text);
            match.PunktZahlzumLeg = Int32.Parse( cBoxPunktzahl.Text );

            foreach (String Name in lstBoxSpieler.Items)
            {
                MatchSpieler matchspieler = new MatchSpieler(Name);
                matchspieler.AktuellesSet.Nummer = 1;
                matchspieler.AktuellesLeg.Nummer = 1;
                matchspieler.AktuellePunktZahl = match.PunktZahlzumLeg;
                match.SpielerList.Add (matchspieler);
            }




            MatchModel matchmodel = new MatchModel(match);
            MatchController matchController = new MatchController( matchmodel );

            _formMatch.NewGame(matchmodel, matchController);
            this.Close();


        }

        private void BtnSpielerDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstBoxSpieler.SelectedIndex >= 0)
                this.lstBoxSpieler.Items.RemoveAt(this.lstBoxSpieler.SelectedIndex);
        }
    }
}
