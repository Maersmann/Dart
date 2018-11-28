using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Programm.Info
{
    /// <summary>
    /// Interaktionslogik für FormCopyright.xaml
    /// </summary>
    public partial class FormLicense : Window
    {
        public FormLicense()
        {
            InitializeComponent();

            richTextBox.AppendText( "Bilder" );
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Match“ by Viktor Petrovich Ivlichev https://www.iconfinder.com/aha-soft is licensed under a Free for commercial use");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Undo“ by Yannick Lung https://www.iconfinder.com/yanlu is licensed under a Free for commercial use");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „NewGame“ by Field 5 Agata Kuczmińska  https://www.iconfinder.com/Field5 is licensed under a Free for commercial use");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Options“ by Anastasya Bolshakova https://www.iconfinder.com/nastu_bol is licensed under Creative Commons license: http://creativecommons.org/licenses/by/3.0/");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Menu“ by Chanut is Industries https://www.iconfinder.com/Chanut-is is licensed under Creative Commons license: http://creativecommons.org/licenses/by/3.0/");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Info“ Alina Agafitei https://www.iconfinder.com/alina.agafitei.73  is licensed under a Free for commercial use");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Lizenz„ by Benjamin STAWARZ https://www.iconfinder.com/butterflytronics is licensed under Creative Commons license: http://creativecommons.org/licenses/by/3.0/");
            richTextBox.AppendText(Environment.NewLine);
            richTextBox.AppendText("- „Neuer Spieler„ by ionics https://ionicons.com/ is licensed under MIT License");
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
