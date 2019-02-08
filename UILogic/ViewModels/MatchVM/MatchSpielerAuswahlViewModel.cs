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
using UILogic.Models.Matchmodels;

namespace UILogic.ViewModels.MatchVM
{
    public class MatchSpielerAuswahlViewModel : ViewModelBase
    {
        private Matchmodel _Matchmodel;
        

        public ICommand INeuenSpielerAuswaehlenCommand { get; private set; }

        public MatchSpielerAuswahlViewModel()
        {
            _Matchmodel = new Matchmodel();


            AnzahlLeg = 3;
            AnzahlSet = 5;
            Punktzahl = 501;

            
            INeuenSpielerAuswaehlenCommand = new RelayCommand(()  => MessengerInstance.Send(new OpenAuswahlSpielerViewMessage()));

            Messenger.Default.Register<AddNeuenSpielerMessage>(this, (message) =>
            {
                _Matchmodel.SpielerList.Add(new MatchspielerModel() { Name = message.newSpieler.Spitzname,
                                                                      MatchSpielerID = message.newSpieler.ID,
                                                                      GewonneneLeg = 0
                                                                    } );
            });
        }

        public int AnzahlLeg
        {
            get { return _Matchmodel.AnzahlLeg; }
            set
            {
                _Matchmodel.AnzahlLeg = value;
                RaisePropertyChanged("AnzahlLeg");
            }
        }

        public int AnzahlSet
        {
            get { return _Matchmodel.AnzahlSet; }
            set
            {
                _Matchmodel.AnzahlSet = value;
                RaisePropertyChanged("AnzahlSet");
            }
        }

        public int Punktzahl
        {
            get { return _Matchmodel.Punktzahl; }
            set
            {
                _Matchmodel.Punktzahl = value;
                RaisePropertyChanged("Punktzahl");
            }
        }

        public ObservableCollection<MatchspielerModel> Datenquelle
        {

            get
            {
                return this._Matchmodel.SpielerList;
            }

            set
            {
                _Matchmodel.SpielerList = value;
                RaisePropertyChanged("Datenquelle");
            }
        }

    }

}
