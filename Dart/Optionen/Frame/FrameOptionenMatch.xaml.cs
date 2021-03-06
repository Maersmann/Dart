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
          public FrameOptionenMatch(OptionGame inOptionGame)
        {
            InitializeComponent();

            this.DataContext =  inOptionGame;


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

    }
}
