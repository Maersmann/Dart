using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace Dart.Info
{
    /// <summary>
    /// Interaktionslogik für FormInfo.xaml
    /// </summary>
    public partial class FormInfo : Window
    {
        public FormInfo()
        {
            InitializeComponent();
            richTextBox.AppendText("Diese Software steht unter GNU GPL Version 3. https://github.com/Maersmann/Dart/blob/Master/LICENSE");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("Der Quellcode ist bei GitHub verfügbar. https://github.com/Maersmann/Dart/");
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
