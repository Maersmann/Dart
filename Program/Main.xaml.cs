﻿using System;
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
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;
using Programm.Info;
using Programm.Person;
using Programm.MatchViews.Forms;
using infrastructure;
using Programm.OptionenViews;

namespace Programm
{
    /// <summary>
    /// Interaktionslogik für Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        private FormMatch _formMatch;
        private StartBildschirm _startBildschirm;

        public Main()
        {
            InitializeComponent();
            if (_startBildschirm == null)
                _startBildschirm = new StartBildschirm();

            Container.NavigationService.Navigate(_startBildschirm);

            var StartRepo = new StartRepo();
            StartRepo.SetVerbindung();


        }

        private void rbMatch_Click(object sender, RoutedEventArgs e)
        {
            if (_formMatch == null)
            {
                _formMatch = new FormMatch(this);
                rbMatchRedo.IsEnabled = false;
                rbMatchUndo.IsEnabled = false;
                rbStatistikMatchAverage.IsEnabled = false;
                rbStatistikMatchBestWerte.IsEnabled = false;
                rbMatchNewGame.Click += _formMatch.rbMatchNewGame_Click;
                rbStatistikMatchAverage.Click += _formMatch.rbStatistikMatchAverage_Click;
                rbStatistikMatchBestWerte.Click += _formMatch.rbStatistikMatchBestWerte_Click;
                rbMatchUndo.Click += _formMatch.rbMatchUndo_Click;
                rbMatchRedo.Click += _formMatch.rbMatchRedo_Click;
            }


            Container.NavigationService.Navigate(_formMatch);
        }




        private void Container_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Content == _formMatch)
            {
                ribboncontextMatch.Visibility = Visibility.Visible;
                ribbonMatch.IsSelected = true;
            }
            else
                ribboncontextMatch.Visibility = Visibility.Hidden;
        }


        private void ribbonMenuClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void ribbonMenuOptionen_Click(object sender, RoutedEventArgs e)
        {
            var option = new OptionenView();
            
            option.ShowDialog();
            option.Close();
        }

        private void ribbonMenuCopyright_Click(object sender, RoutedEventArgs e)
        {
            FormLicense formCopy = new FormLicense();
            formCopy.ShowDialog();
        }

        private void ribbonMenuInfo_Click(object sender, RoutedEventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();
        }


        

        private void RbNewSpieler_Click(object sender, RoutedEventArgs e)
        {
            AddPersonView formaddPerson = new AddPersonView();
            formaddPerson.ShowDialog();
        }
    }
}