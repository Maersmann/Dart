using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Programm.Optionen.Utils;
using Programm.MatchViews.Matchobjekte;
using infrastructure.MatchEntity;
using Programm.Person;

namespace Programm.MatchViews.Forms
{
    /// <summary>
    /// Interaktionslogik für FormSpielerAuswahl.xaml
    /// </summary>
    public partial class MatchSpielerAuswahlView : Window
    {

        FormMatch _formMatch;

        public MatchSpielerAuswahlView( FormMatch pFormMatch )
        {
            InitializeComponent();
            _formMatch = pFormMatch;
            cBoxPunktzahl.SelectedIndex = 0;

           /* OptionIni optIni = new OptionIni();
            cBoxPunktzahl.Text = optIni.OptionGame.Punktzahl.ToString();
            txtAnzahlLeg.Text = optIni.OptionGame.LegZumSet.ToString();
            TxtAnzahlSet.Text = optIni.OptionGame.SetZumSieg.ToString(); */
        }

        private void btnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            AuswahlPersonView auswahlPersonView = new AuswahlPersonView();
            auswahlPersonView.ShowDialog();

            return;

            if(lstBoxSpieler.Items.Count >= 8)
            {
                MessageBox.Show("Es sind nur 8 Spieler maximal möglich");
                return;
            }

       
        }


        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            
            if (lstBoxSpieler.Items.Count == 0)
            {
                MessageBox.Show("Keine Spieler vorhanden!");
                return;
            }

           /* if (txtAnzahlLeg.Text.Equals("") )
            {
                txtAnzahlLeg.Clear();
                MessageBox.Show("Die Legs fehlen!");
                return;
            }

            if (TxtAnzahlSet.Text.Equals("") )
            {
                TxtAnzahlSet.Clear();
                MessageBox.Show("Die Sets fehlen!");
                return;
            }

            if (Convert.ToInt32(TxtAnzahlSet.Text) < 0)
            {
                TxtAnzahlSet.Clear();
                MessageBox.Show("Anzahl Sets muss positiv sein");
                return;
            }

            if (Convert.ToInt32(txtAnzahlLeg.Text) <= 0)
            {
                txtAnzahlLeg.Clear();
                MessageBox.Show("Anzahl Legs muss über 0 sein");
                return;
            }*/

            DialogResult = true;

          

            

            foreach (String Name in lstBoxSpieler.Items)
            {
                //MatchSpieler matchspieler = new MatchSpieler(Name);
                //matchspieler.AktuellesSet.Nummer = 1;
                //matchspieler.AktuellesLeg.Nummer = 1;
          //      matchspieler.AktuellePunktZahl = match.PunktZahlzumLeg;
                //match.SpielerList.Add (matchspieler);
            }




            //MatchModel matchmodel = new MatchModel(match);
         //   MatchController matchController = new MatchController( matchmodel );

         //   _formMatch.NewGame(matchmodel, matchController);
            this.Close();


        }

        private void BtnSpielerDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.lstBoxSpieler.SelectedIndex >= 0)
                this.lstBoxSpieler.Items.RemoveAt(this.lstBoxSpieler.SelectedIndex);
        }

        private void txtAnzahlLeg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtAnzahlSet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
