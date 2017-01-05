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

namespace Dart.Match.Forms
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


        public FormMatch()
        {
            InitializeComponent();
            ClearView();
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


        }


        private void ClearView()
        {
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
            _MatchCareTaker.AddMemento(_MatchModel.getMemento());

            if (new Kontrolle().Check(TxtWurfEins.Text, TxtWurfZwei.Text, TxtWurfDrei.Text))
            {
                _MatchController.WurfBerechnen(Convert.ToInt32(TxtWurfEins.Text), Convert.ToInt32(TxtWurfZwei.Text), Convert.ToInt32(TxtWurfDrei.Text));
            }
            else
            {
                return;

            }
            if (_MatchController.SpielBeendet)
            {
                FormSpielerAuswahl newSpiel = new FormSpielerAuswahl( this );
                newSpiel.Show();
                //this.Close();
            }
           
            ShowSpielerDaten();
            AktualisiereView();
        }



        private void AktualisiereView()
        {
            TxtWurfDrei.Text = "";
            TxtWurfZwei.Text = "";
            TxtWurfEins.Text = "";
            TxtWurfEins.Focus();

            lblPunktzahl.Foreground = Brushes.Black;

            //menuRueckgaengig.IsEnabled = (_MatchCareTaker.canUndo());
            //menuWiederholen.IsEnabled = (_MatchCareTaker.CanRedo());            

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

        private void NeuePunktzahl(int pPunktzahl)
        {
            if (!_TextBoxFocus.IsFocused)
            {
                _TextBoxFocus.Focus();
            }
                 
            _TextBoxFocus.Text = Convert.ToString(pPunktzahl);
            ChangeTxtBoxFocus();
        }

        #region ButtonClicks

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(0);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(3);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(6);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(8);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(7);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(9);
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(10);
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(11);
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(12);
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(13);
        }

        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(14);
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(15);
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(16);
        }

        private void btn17_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(17);
        }

        private void btn18_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(18);
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(20);
        }

        private void btnD20_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(40);
        }

        private void btnT20_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(60);
        }

        private void btnD18_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(36);
        }

        private void btnT18_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(54);
        }

        private void btnD17_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(34);
        }

        private void btnT17_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(51);
        }

        private void btnD16_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(32);
        }

        private void btnT16_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(48);
        }

        private void btnD15_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(30);
        }

        private void btnT15_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(45);
        }

        private void btnD14_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(28);
        }

        private void btnT14_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(42);
        }

        private void btnD13_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(26);
        }

        private void btnT13_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(39);
        }

        private void btnD12_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(24);
        }

        private void btnT12_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(36);
        }

        private void btnT11_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(33);
        }

        private void btnD11_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(22);
        }

        private void btnD10_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(20);
        }

        private void btnT10_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(30);
        }

        private void btnD9_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(18);
        }

        private void btnT9_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(27);
        }

        private void btnT8_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(24);
        }

        private void btnD8_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(16);
        }

        private void btnD7_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(14);
        }

        private void btnD6_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(12);
        }

        private void btnT7_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(21);
        }

        private void btnT6_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(18);
        }

        private void btnT5_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(15);
        }

        private void btnD5_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(10);
        }

        private void btnD4_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(8);
        }

        private void btnT4_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(12);
        }

        private void btnT3_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(9);
        }

        private void btnD3_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(6);
        }

        private void btnD2_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(4);
        }

        private void btnD1_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(2);
        }

        private void btnT2_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(6);
        }

        private void btnT1_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(3);
        }

        private void btnDBull_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(50);
        }

        private void btnBull_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(25);
        }

        private void btn19_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(19);
        }

        private void btnD19_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(38);
        }

        private void btnT19_Click(object sender, RoutedEventArgs e)
        {
            NeuePunktzahl(57);
        }
        #endregion

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

        public void doRueckgaengig()
        {
            if (_MatchCareTaker.canUndo())
            {
                _MatchModel = _MatchCareTaker.Undo(_MatchModel.getMemento()).getMatchModel();
                _MatchController._Matchmodel = _MatchModel;
                ShowSpielerDaten();
                AktualisiereView();
            }
        }

        public void doWiederholen()
        {
            if (_MatchCareTaker.CanRedo())
            {
                _MatchModel = _MatchCareTaker.Redo(_MatchModel.getMemento()).getMatchModel();
                _MatchController._Matchmodel = _MatchModel;
                ShowSpielerDaten();
                AktualisiereView();
            }
        }
    }
}
