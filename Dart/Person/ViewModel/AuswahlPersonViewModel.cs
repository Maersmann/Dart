using GalaSoft.MvvmLight;
using Repository.SpielerEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Repository.Datenbank;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart.Person.ViewModel
{
    public class AuswahlPersonViewModel : ViewModelBase
    {

        private ObservableCollection<Player> _Players = null;

        public AuswahlPersonViewModel()
        {
           
           


        }

        public IEnumerable<Player> Datenquelle
        {

            get
            {

                    var dbContext = AppVariables.getDbContext();

                    dbContext.DetachAll(dbContext.Players);

                    this._Players = new ObservableCollection<Player>(dbContext.Players.ToList());

                return this._Players;
            }
        }


    }
}
