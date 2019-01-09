using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using infrastructure.SpielerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace UILogic.ViewModels.Person
{
    public class AddPersonViewModel : ViewModelBase
    {
        public Spieler newPlayer { get; private set; }

        public ICommand IAddPlayerCommand { get; set; }


        public AddPersonViewModel()
        {
            newPlayer = new Spieler();
            IAddPlayerCommand = new RelayCommand(AddPlayerCommand);
        }

        public void AddPlayerCommand()
        {
            var dbcontext = AppVariables.getDbContext();
            dbcontext.Players.Add(newPlayer);

            var players = dbcontext.Players;

            dbcontext.SaveChanges();
        }    

    }

}
