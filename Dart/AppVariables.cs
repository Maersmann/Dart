using Dart.Datenbank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    static class AppVariables
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
