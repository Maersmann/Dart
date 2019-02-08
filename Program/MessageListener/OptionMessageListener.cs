using GalaSoft.MvvmLight.Messaging;
using Programm.OptionenViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UILogic.Messages.OptionMessage;

namespace Program.MessageListener
{
    public class OptionMessageListener
    {
        public OptionMessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            Messenger.Default.Register<OpenOptionView>(
                this,
                msg =>
                {
                    var frame = GetDescendantFromName(Application.Current.Windows.OfType<OptionenView>().FirstOrDefault(), "frameOptionen") as Frame;

                    if (frame != null)
                    {
                        if (msg.ViewName == "Match")
                            frame.Source = new Uri("../OptionenViews/OptionenMatchView.xaml", UriKind.Relative);
                    }
                });
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }

        public bool BindableProperty => true;
    }
}
