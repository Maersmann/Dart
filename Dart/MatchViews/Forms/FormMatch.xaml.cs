using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Dart.Utils;
using Dart.Finish;
using Dart.Memento;
using Dart.Statistiken.Match.Forms;
using Dart.MatchViews.Matchobjekte;

namespace Dart.MatchViews.Forms
{
    
    public partial class FormMatch : Page
    {
        static private String LBLNAME = " ist dran";
        static private String LBLANZAHLSECHZIG = "Anzahl 60 >=: ";
        static private String LBLANZAHLHUNDERT = "Anzahl 100 >=: ";
        static private String LBLANZAHLHUNDERTVIERZIG = "Anzahl 140 >=: ";
        static private String LBLANZAHLHUNDERTSIEBZIG = "Anzahl 170 >=: ";
        static private String LBLANZAHLHUNDERTACHZIG = "Anzahl 180: ";
        static private String LBLGEWONNENLEGS = "Gewonnene Legs: ";
        static private String LBLGEWONNENSETS = "Gewonnene Sets: ";
        static private String LBLWUERFE = "Würfe: ";
        static private String LBLAVERAGESPIEL = "Average Gesamt: ";
        static private String LBLAVERAGELEG = "Average Leg: ";
        static private String LBLSHORTESTLEG = "Shortest Leg: ";
        static private String LBLLONGESTLEG = "Longest Leg: ";
        static private String LBLAVERAGESET = "Average Set: ";

        MatchController _MatchController;
        MatchModel _MatchModel;
        MatchCaretaker _MatchCareTaker;
        TextBox _TextBoxFocus;
        FinishWeg _Finish;
        Main _Main;


        public FormMatch(Main pMain)
        {
            InitializeComponent();
            ClearView();
            _Main = pMain;
        }

        public void NewGame(MatchModel pMatchModel, MatchController pMatchController)
        {
            _MatchController = pMatchController;
             _MatchModel = pMatchModel;
            _MatchCareTaker = new MatchCaretaker();
            _Finish = new FinishWeg();

             ShowSpielerDaten();
             AktualisiereView();
             _TextBoxFocus = TxtWurfEins;
             TxtWurfEins.Focus();

            BtnNaechster.IsEnabled = true;
            TxtWurfDrei.IsEnabled = true;
            TxtWurfZwei.IsEnabled = true;
            TxtWurfEins.IsEnabled = true;

            setGridSpielerAllVisible();
            AktualisiereGridSpieler();
            int AnzahlSpieler = _MatchModel.getAnzahlSpieler();
            for (int SpielerBoxUnvisible = AnzahlSpieler +1 ; SpielerBoxUnvisible < 9; SpielerBoxUnvisible++)
            {
                String nameGrp = "GrpSpieler" + SpielerBoxUnvisible;
                Object GridObj  = this.FindName(nameGrp);
                if ((GridObj is Grid) && (GridObj != null))
                    (GridObj as Grid).Visibility = Visibility.Hidden;
            }

            DockPnlSpieler.Visibility = Visibility.Visible;

        }

        private void setGridSpielerAllVisible()
        {
            for (int SpielerBoxVisible = 1; SpielerBoxVisible< 9; SpielerBoxVisible++)
            {
                String nameGrp = "GrpSpieler" + SpielerBoxVisible;
                Object GridObj = this.FindName(nameGrp);

                if ( (GridObj is Grid) && ( GridObj != null ))
                    (GridObj as Grid).Visibility = Visibility.Visible;
            }
        }

        private void AktualisiereGridSpieler()
        {
            List<MatchSpieler> listSpieler = _MatchModel.getSpielerList();

            for (int SpielerBoxDataPos = 1; SpielerBoxDataPos <= listSpieler.Count ; SpielerBoxDataPos++)
            {
                MatchSpieler AktSpieler = listSpieler[SpielerBoxDataPos -1];
                String nameGrp = "lblSpieler" + SpielerBoxDataPos + "Name";
                Object GridObj = this.FindName(nameGrp);
                if ((GridObj is Label) && (GridObj != null))
                    (GridObj as Label).Content = AktSpieler.Spieler.Spitzname;

                nameGrp = "lblSpieler" + SpielerBoxDataPos + "Punktzahl";
                GridObj = this.FindName(nameGrp);
                if ((GridObj is Label) && (GridObj != null))
                    (GridObj as Label).Content = AktSpieler.AktuellePunktZahl;

                nameGrp = "lblSpieler" + SpielerBoxDataPos + "Legs";
                GridObj = this.FindName(nameGrp);
                if ((GridObj is Label) && (GridObj != null))
                    (GridObj as Label).Content = AktSpieler.AnzahlLegGewonnen.ToString();

                nameGrp = "lblSpieler" + SpielerBoxDataPos + "Sets";
                GridObj = this.FindName(nameGrp);
                if ((GridObj is Label) && (GridObj != null))
                    (GridObj as Label).Content = AktSpieler.AnzahlSetGewonnen.ToString();

            }
        }

        private void ClearView()
        {
            setGridSpielerAllVisible();
            DockPnlSpieler.Visibility = Visibility.Hidden;
            lblAnzahl60.Content = LBLANZAHLSECHZIG ;
            lblAnzahl100.Content = LBLANZAHLHUNDERT ;
            lblAnzahl140.Content = LBLANZAHLHUNDERTVIERZIG ;
            lblAnzahl180.Content = LBLANZAHLHUNDERTACHZIG ;
            lblSpielerName.Content = "";
            lblAverageLeg.Content = LBLAVERAGELEG ;
            lblAverageSet.Content = LBLAVERAGESET ;
            lblAverageSpiel.Content = LBLAVERAGESPIEL ;
            lblWuerfe.Content = LBLWUERFE ;
            lblPunktzahl.Content = ""; ;
            lblGewonneLeg.Content = LBLGEWONNENLEGS ;
            lblGewonnenSet.Content = LBLGEWONNENSETS ;
            lblAnzahl170.Content = LBLANZAHLHUNDERTSIEBZIG ;
            lblBestLeg.Content = LBLSHORTESTLEG ;
            lblWorstLeg.Content = LBLLONGESTLEG ;
            lblFinishDrei.Content = "";
            lblFinishEins.Content = "";
            lblFinishWeg.Content = "";
            lblFinishZwei.Content = "";
            BtnNaechster.IsEnabled = false;
            TxtWurfDrei.IsEnabled = false;
            TxtWurfZwei.IsEnabled = false;
            TxtWurfEins.IsEnabled = false;

            TxtWurfDrei.Text = "";
            TxtWurfZwei.Text = "";
            TxtWurfEins.Text = "";
        }

        private void ShowSpielerDaten()
        {
            lblAnzahl60.Content = LBLANZAHLSECHZIG + _MatchModel.getAnzahlSechzig();
            lblAnzahl100.Content = LBLANZAHLHUNDERT + _MatchModel.getAnzahlHundert();
            lblAnzahl140.Content = LBLANZAHLHUNDERTVIERZIG + _MatchModel.getAnzahlHundertVierzig();
            lblAnzahl180.Content = LBLANZAHLHUNDERTACHZIG + _MatchModel.getAnzahlHundertAchzig();
            lblSpielerName.Content = _MatchModel.getName() + LBLNAME;
            lblAverageLeg.Content = LBLAVERAGELEG + _MatchModel.getAverageLeg();
            lblAverageSet.Content = LBLAVERAGESET + _MatchModel.getAverageSet();
            lblAverageSpiel.Content = LBLAVERAGESPIEL + _MatchModel.getAverageSpiel();
            lblWuerfe.Content = LBLWUERFE + _MatchModel.getLegWuerfe();
            lblPunktzahl.Content = _MatchModel.getPunktestand();
            lblGewonneLeg.Content = LBLGEWONNENLEGS + _MatchModel.getGewonnenLegs();
            lblGewonnenSet.Content = LBLGEWONNENSETS + _MatchModel.getGewonnenSet();
            lblAnzahl170.Content = LBLANZAHLHUNDERTSIEBZIG + _MatchModel.getAnzahlHundertSiebzig();
            lblBestLeg.Content = LBLSHORTESTLEG + _MatchModel.getShortestLeg();
            lblWorstLeg.Content = LBLLONGESTLEG + _MatchModel.getLongestLeg();
        }

        private void BtnNaechster_Click(object sender, RoutedEventArgs e)
        {
            Naechster();
        }

        private void Naechster()
        {
            if (new Kontrolle().Check(TxtWurfEins.Text, TxtWurfZwei.Text, TxtWurfDrei.Text))
            {
                _MatchCareTaker.AddMemento(_MatchModel.getMemento());
                _MatchController.WurfBerechnen(Convert.ToInt32(TxtWurfEins.Text), Convert.ToInt32(TxtWurfZwei.Text), Convert.ToInt32(TxtWurfDrei.Text));
            }
            else
            {
                return;

            }
            if (_MatchController.SpielBeendet)
            {
                ClearView();

                _Main.rbMatchRedo.IsEnabled = false;
                _Main.rbMatchUndo.IsEnabled = false;

            }
            else
            { 
                ShowSpielerDaten();
                AktualisiereGridSpieler();
                AktualisiereView();
          
            }

        }


        private void AktualisiereView()
        {
            TxtWurfDrei.Text = "";
            TxtWurfZwei.Text = "";
            TxtWurfEins.Text = "";
            TxtWurfEins.Focus();

            lblPunktzahl.Foreground = Brushes.Black;

            _Main.rbMatchUndo.IsEnabled = (_MatchCareTaker.canUndo());
            _Main.rbMatchRedo.IsEnabled = (_MatchCareTaker.CanRedo());            

            if (_MatchController.isFinishBereich())
            {
                _Finish.AktualisiereFinsish(_MatchModel.getPunktestand(),3);
                gridFinish.Visibility = Visibility.Visible;
                lblFinishEins.Content = _Finish.getWurf1();
                lblFinishZwei.Content = _Finish.getWurf2();
                lblFinishDrei.Content = _Finish.getWurf3();
            }
            else
            {
                gridFinish.Visibility = Visibility.Hidden;
            }
        }

        private void ChangeTxtBoxFocus()
        {
            if (_TextBoxFocus == TxtWurfEins)
            {
                _TextBoxFocus = TxtWurfZwei;
            }
            else if (_TextBoxFocus == TxtWurfZwei)
            {
                _TextBoxFocus = TxtWurfDrei;
            }
            _TextBoxFocus.Focus();  
        }
          

        #region EingabeKontrolle

        private void TxtWurfDrei_GotFocus(object sender, RoutedEventArgs e)
        {
            _TextBoxFocus = TxtWurfDrei;
            isNewFinish();
        }

        private void TxtWurfZwei_GotFocus(object sender, RoutedEventArgs e)
        {
            _TextBoxFocus = TxtWurfZwei;
            isNewFinish();
        }

        private void TxtWurfEins_GotFocus(object sender, RoutedEventArgs e)
        {
            _TextBoxFocus = TxtWurfEins;
            isNewFinish();
        }

        

        private void TxtWurfEins_TextChanged(object sender, TextChangedEventArgs e)
        {

          //  if (_Enter)
           // {
           //     isNewFinish();
           //     _Enter = false;
           //     return;
           // }

            if (TxtWurfEins.Text.Equals(""))
            {
                isNewFinish();
                return;
            }

            int Wurf = -1;
            if (!int.TryParse(TxtWurfEins.Text, out Wurf))
            {
                TxtWurfEins.Clear();

                MessageBox.Show("Keine Zahl eingegeben");
                return;
            }
            else
            {
                if (Wurf > 60 )
                {
                    MessageBox.Show("Mehr als 60 eingegeben");
                    TxtWurfEins.Clear();
                    return;
                }

                if (Wurf > 6 || Wurf == 0)
                {
                    ChangeTxtBoxFocus();
                }
            }
        }

        private void TxtWurfZwei_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (_Enter )
            //{
              //  isNewFinish();
             //   _Enter = false;
            //    return;
            //}

            if (TxtWurfZwei.Text.Equals(""))
            {
                isNewFinish();
                return;
            }

            int Wurf = -1;
            if (!int.TryParse(TxtWurfZwei.Text, out Wurf))
            {
                TxtWurfZwei.Clear();
                MessageBox.Show("Keine Zahl eingegeben");
                return;
            }
            else
            {
                if (Wurf > 60)
                {
                    MessageBox.Show("Mehr als 60 eingegeben");
                    TxtWurfZwei.Clear();
                    return;
                }

                if (Wurf > 6 || Wurf == 0)
                {
                    ChangeTxtBoxFocus();
                }
            }
        }

        private void isNewFinish()
        {
            if (_MatchModel.getPunktestand() > 170)
            {
                return;
            }

            Int32 Wurf1 = 0;
            Int32 Wurf2 = 0;
            Int32 Wurf3 = 0;

            Int32.TryParse(TxtWurfEins.Text, out Wurf1);
            Int32.TryParse(TxtWurfZwei.Text, out Wurf2);
            Int32.TryParse(TxtWurfDrei.Text, out Wurf3);

            if (_Finish.AktualisiereFinsish(_MatchModel.getPunktestand() - Wurf1 - Wurf2 - Wurf3, CheckEmptyTxtBox()))
            {
                gridFinish.Visibility = Visibility.Visible;
                lblFinishEins.Content = _Finish.getWurf1();
                lblFinishZwei.Content = _Finish.getWurf2();
                lblFinishDrei.Content = _Finish.getWurf3();
                lblPunktzahl.Content = _MatchModel.getPunktestand() - Wurf1 - Wurf2 - Wurf3;
                if (Wurf1 + Wurf2 + Wurf3 > 0 )
                {
                    lblPunktzahl.Foreground = Brushes.Red; 
                }
                
            }
            else
            {
                if (_MatchModel.getPunktestand() - Wurf1 - Wurf2 - Wurf3 <= 1 || CheckEmptyTxtBox() == 0)
                {
                    lblPunktzahl.Content = _MatchModel.getPunktestand();
                    lblPunktzahl.Foreground = Brushes.Black;
                }
                else
                {
                    lblPunktzahl.Content = _MatchModel.getPunktestand() - Wurf1 - Wurf2 - Wurf3;
                    lblPunktzahl.Foreground = Brushes.Red;
                }

                gridFinish.Visibility = Visibility.Hidden;
                
            }

        }

        private int CheckEmptyTxtBox()
        {
            int AnzahlLeer = 0;
            if (TxtWurfEins.Text.Equals(""))
            {
                AnzahlLeer++;
            }
            if (TxtWurfZwei.Text.Equals(""))
            {
                AnzahlLeer++;
            }
            if (TxtWurfDrei.Text.Equals(""))
            {
                AnzahlLeer++;
            }
            return AnzahlLeer;
        }

        private void TxtWurfDrei_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (_Enter )
           // {
           //     isNewFinish();
           //     _Enter = false;
           //     return;
           // }

            if (TxtWurfDrei.Text.Equals(""))
            {
                isNewFinish();
                return;
            }

            int Wurf = 0;
            if (!int.TryParse(TxtWurfDrei.Text, out Wurf))
            {
                TxtWurfDrei.Clear();
                MessageBox.Show("Keine Zahl eingegeben");
                return;
            }
            else if (Wurf > 60)
            {
                MessageBox.Show("Mehr als 60 eingegeben");
                TxtWurfDrei.Clear();
                return;
            }
        }

        private void TxtWurfEins_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ChangeTxtBoxFocus();
        }

        private void TxtWurfZwei_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ChangeTxtBoxFocus();
        }

        private void TxtWurfDrei_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Naechster();       
        }


        #endregion



        public MatchModel getMatchModel()
        { 
            return _MatchModel;
        }

        public void rbStatistikMatchAverage_Click(object sender, RoutedEventArgs e)
        {
            FormStatistikMatchAverage formAverage = new FormStatistikMatchAverage(_MatchModel);
            formAverage.ShowDialog();
        }

        public void rbStatistikMatchBestWerte_Click(object sender, RoutedEventArgs e)
        {
            FormStatistikMatchBestWerte formBestWerte = new FormStatistikMatchBestWerte(_MatchModel);
            formBestWerte.ShowDialog();
        }

        public void rbMatchUndo_Click(object sender, RoutedEventArgs e)
        {
            if (_MatchCareTaker.canUndo())
            {
                _MatchModel = _MatchCareTaker.Undo(_MatchModel.getMemento()).getMatchModel();
                _MatchController._Matchmodel = _MatchModel;
                ShowSpielerDaten();
                AktualisiereView();
            }
        }

        public void rbMatchRedo_Click(object sender, RoutedEventArgs e)
        {
            if (_MatchCareTaker.CanRedo())
            {
                _MatchModel = _MatchCareTaker.Redo(_MatchModel.getMemento()).getMatchModel();
                _MatchController = new MatchController(_MatchModel);
                ShowSpielerDaten();
                AktualisiereView();
            }
        }

        public void rbMatchNewGame_Click(object sender, RoutedEventArgs e)
        {

            FormSpielerAuswahl formSpielerAuswahl = new FormSpielerAuswahl( this );
            bool? DialogResult = formSpielerAuswahl.ShowDialog();

            if (DialogResult == true)
            {
                _Main.rbStatistikMatchAverage.IsEnabled = true;
                _Main.rbStatistikMatchBestWerte.IsEnabled = true;
            }

        }
    }
}
