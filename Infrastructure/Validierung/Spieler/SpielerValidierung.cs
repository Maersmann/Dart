using infrastructure;
using Infrastructure.BaseType;
using infrastructure.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validierung.Spieler
{
    public class SpielerValidierung : IValidierung
    {
        public bool ValidateSpitzname( String inSpitzname, out ICollection<string> validationErrors)
        {
            validationErrors = new List<String>();

            if (inSpitzname.Length > 250)
                validationErrors.Add("Der Spitzname ist zu lang");

            if (inSpitzname.Length == 0)
                validationErrors.Add("Spielname darf nicht leer sein");


            var dbcontext = GlobalVariables.getDbContext();

            dbcontext.DetachAll(dbcontext.Players);

            var Player =  dbcontext.Players.Where(x => x.Spitzname.ToLower() == inSpitzname.ToLower()).FirstOrDefault( );

            if (Player == null) return validationErrors.Count == 0;

            if (Player.ID > 0)
                validationErrors.Add("Spitzname ist schon vorhanden");


            return validationErrors.Count == 0;
        }
    }
}
