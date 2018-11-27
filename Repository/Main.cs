using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class StartRepo
    {
        public void SetVerbindung()
        {
            setConnection();
        }

        private void setConnection()
        {
            var builder = new FbConnectionStringBuilder();
            builder.Database = @"C:\Dart.fdb";
            builder.Port = 3050;
            builder.ServerType = FbServerType.Default;
            builder.UserID = "SYSDBA";
            builder.Password = "masterkey";
            builder.DataSource = "localhost";
            builder.Dialect = 3;
            builder.Charset = "None";
            builder.ConnectionLifeTime = 15;
            builder.Pooling = true;
            builder.MaxPoolSize = 50;
            builder.PacketSize = 8192;

            GlobalVariables.ConnectionString = builder.ConnectionString;
            var dbContext = GlobalVariables.getDbContext();

            dbContext.Database.Connection.ConnectionString = GlobalVariables.ConnectionString;

            try
            {
                dbContext.Database.Connection.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
