using GalaSoft.MvvmLight.Messaging;
using Programm.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UILogic.Messages.Match;

namespace Program.MessageListener
{
    public class MatchSpielerAuswahlMessageListener
    {
        public MatchSpielerAuswahlMessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            Messenger.Default.Register<OpenAuswahlSpielerViewMessage>(
                this,
                msg =>
                {
                    var window = new AuswahlPersonView();

                    window.ShowDialog();
                });
        }

        public bool BindableProperty => true;
    }
}
