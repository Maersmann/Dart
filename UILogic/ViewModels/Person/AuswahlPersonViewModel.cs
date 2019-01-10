using GalaSoft.MvvmLight;
using infrastructure.SpielerEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using infrastructure.Datenbank;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using UILogic.Messages.Match;

namespace UILogic.ViewModels.Person
{
    public class AuswahlPersonViewModel : ViewModelBase
    {

        private ObservableCollection<Spieler> _SpielerList = null;

        private Spieler _SelectedSpieler { get; set; }

        public ICommand ISpielerAusgewaehltCommand { get; private set; }


        public AuswahlPersonViewModel()
        {
            ISpielerAusgewaehltCommand = new RelayCommand<IClosable>(this.SpielerAusgewaehlt);
        }

        public IEnumerable<Spieler> SpielerList
        {

            get
            {

                    var dbContext = AppVariables.getDbContext();

                    dbContext.DetachAll(dbContext.Players);

                    this._SpielerList = new ObservableCollection<Spieler>(dbContext.Players.ToList());

                return this._SpielerList;
            }
        }

        public Spieler SelectedSpieler
        { 
            get{ return _SelectedSpieler; }

            set
            {
                _SelectedSpieler = value;
                RaisePropertyChanged("SelectedSpieler");
            }

        }

        public void SpielerAusgewaehlt(IClosable parameter)
        {
            Messenger.Default.Send<AddNeuenSpielerMessage>(new AddNeuenSpielerMessage() { SpielerID = _SelectedSpieler.ID });

            var closable = parameter as IClosable;
            if (closable != null)
            {
                closable.Close();
                ViewModelLocator.ClearAuswahlPersonViewModel();
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }



    }
}
