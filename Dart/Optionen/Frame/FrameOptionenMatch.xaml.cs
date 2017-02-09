﻿using System;
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
using Dart.Optionen.DataModul;

namespace Dart.Optionen.Frame
{
    /// <summary>
    /// Interaktionslogik für OptionenMatch.xaml
    /// </summary>
    public partial class FrameOptionenMatch : Page
    {
   
        private OptionGame _optionGame;

        public FrameOptionenMatch(OptionGame inOptionGame)
        {
            InitializeComponent();

            _optionGame = inOptionGame;

            TxtBoxLegZumSet.Text = _optionGame.LegZumSet.ToString();
            TxtBoxSetZumSieg.Text = _optionGame.SetZumSieg.ToString();
            cBoxPunktzahl.Text = _optionGame.Punktzahl.ToString();
        }

        private void TxtBoxLegZumSet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtBoxSetZumSieg_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _optionGame.LegZumSet = int.Parse(TxtBoxLegZumSet.Text);
            _optionGame.Punktzahl = int.Parse(cBoxPunktzahl.Text);
            _optionGame.SetZumSieg = int.Parse(TxtBoxSetZumSieg.Text);
        }

    }
}
