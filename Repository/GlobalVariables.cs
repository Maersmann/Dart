using infrastructure.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure
{
    public static class GlobalVariables
    {

        private static DbModel dbContext = null;

        public static String ConnectionString { get; set; }

        public static DbModel getDbContext()
        {
            dbContext = dbContext ?? new DbModel(ConnectionString);
            return dbContext;
        }
    }
}
