using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using infrastructure.SpielerEntity;
using Infrastructure.BaseType;
using Infrastructure.Validierung.Spieler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UILogic.BaseTypes;

namespace UILogic.ViewModels.Person
{
    public class AddPersonViewModel : ErrorViewModel
    {
        private String _Spielname;
        private String _Vorname;
        private String _NachName;

        public ICommand IAddPlayerCommand { get; set; }


        public AddPersonViewModel()
        {
            IAddPlayerCommand = new RelayCommand(AddPlayerCommand);
            _Spielname = "";
            _Vorname = "";
            _NachName = "";
    }

        public void AddPlayerCommand()
        {
            

            asd(_Spielname);

            if (_validationErrors.Count > 0) return;

            var newPlayer = new Spieler() { Spitzname = _Spielname, Nachname = _NachName, Voname = _Vorname };

            var dbcontext = AppVariables.getDbContext();
            dbcontext.Players.Add(newPlayer);

            var players = dbcontext.Players;

            dbcontext.SaveChanges();
        }

        public String Spitzname
        {
            get{ return _Spielname; } 
            set
            {
                _Spielname = value;
                asd(_Spielname);
            }
        }



        private void asd(String inSpitzname)
        {
            const string propertyKey = "Spitzname";
            SpielerValidierung spielerValidierung = new SpielerValidierung();
            ICollection<string> validationErrors = null;

            bool isValid = spielerValidierung.ValidateSpitzname(inSpitzname, out validationErrors);

        
            if (!isValid)
            {
                
                _validationErrors[propertyKey] = validationErrors;
               
                RaiseErrorsChanged(propertyKey);
            }
            else if (_validationErrors.ContainsKey(propertyKey))
            {
                
                _validationErrors.Remove(propertyKey);
                
                RaiseErrorsChanged(propertyKey);
            }
        }
  

    }

}
