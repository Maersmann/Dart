using GalaSoft.MvvmLight;
using infrastructure.MatchEntity;
using infrastructure.SpielerEntity;
using System;
using System.Collections.Generic;
using infrastructure.Datenbank;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using UILogic.Messages.Match;
using GalaSoft.MvvmLight.Messaging;

namespace UILogic.ViewModels.MatchVM
{
    public class MatchSpielerAuswahlViewModel : ViewModelBase
    {
        private Match _Match;
        private ObservableCollection<SpielerModel> _Players = null;

        public ICommand INeuenSpielerAuswaehlenCommand { get; private set; }

        public MatchSpielerAuswahlViewModel()
        {
            _Match = new Match();

            AnzahlLeg = 3;
            AnzahlSet = 5;
            Punktzahl = 501;

            this._Players = new ObservableCollection<SpielerModel>();
            INeuenSpielerAuswaehlenCommand = new RelayCommand(()  => MessengerInstance.Send(new OpenAuswahlSpielerViewMessage()));

            Messenger.Default.Register<AddNeuenSpielerMessage>(this, (message) =>
            {
                int i = message.SpielerID;
            });
        }

        public int AnzahlLeg { get; set; }

        public int AnzahlSet { get; set; }

        public int Punktzahl { get; set; }

        public IEnumerable<SpielerModel> Datenquelle
        {

            get
            {
                return this._Players;
            }
        }

    }



    public class SpielerModel
    {
        public int SpielerID {get; set; }

        public String Name { get; set; }
    }
}
