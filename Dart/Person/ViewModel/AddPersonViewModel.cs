using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Repository.SpielerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Repository.Datenbank;

namespace Dart.Person.ViewModel
{
    public class AddPersonViewModel : ViewModelBase
    {
        public Player newPlayer { get; private set; }

        public ICommand toggleExecuteCommand { get; set; }

     
        public AddPersonViewModel()
        {
            newPlayer = new Player();
            toggleExecuteCommand = new RelayCommand(AddPlayerCommand);
        }

        private void AddPlayerCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
