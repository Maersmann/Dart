using GalaSoft.MvvmLight;
using infrastructure.SpielerEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using infrastructure.Datenbank;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UILogic.ViewModels.Person
{
    public class AuswahlPersonViewModel : ViewModelBase
    {

        private ObservableCollection<Spieler> _Players = null;

        public AuswahlPersonViewModel()
        {
           
           


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


    }
}
