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

        private ObservableCollection<Spieler> _Players = null;

        public Spieler SelectedItem { get; set; }

        public ICommand ISpielerAusgewaehltCommand { get; private set; }


        public AuswahlPersonViewModel()
        {
            ISpielerAusgewaehltCommand = new RelayCommand<IClosable>(this.SpielerAusgewaehlt);
        }

        public IEnumerable<Spieler> Datenquelle
        {

            get
            {

                    var dbContext = AppVariables.getDbContext();

                    dbContext.DetachAll(dbContext.Players);

                    this._Players = new ObservableCollection<Spieler>(dbContext.Players.ToList());

                return this._Players;
            }
        }

        public void SpielerAusgewaehlt(IClosable parameter)
        {
            SelectedItem = _Players.First();
            Messenger.Default.Send<AddNeuenSpielerMessage>(new AddNeuenSpielerMessage() { SpielerID = SelectedItem.ID });

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
