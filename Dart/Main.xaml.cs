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
using System.Windows.Shapes;
using Dart.Match;
using Microsoft.Windows.Controls.Ribbon;

namespace Dart
{
    /// <summary>
    /// Interaktionslogik für Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        private FormMatch formMatch;

        public Main()
        {
            InitializeComponent();
        }

        private void rbMatch_Click(object sender, RoutedEventArgs e)
        {
            if (formMatch == null)
            {
                formMatch = new FormMatch();
                try
                {
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    throw;
                }
                
            }


            Container.NavigationService.Navigate(formMatch);
        }
    }
}
