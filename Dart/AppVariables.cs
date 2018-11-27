﻿using Repository.Datenbank;
using Repository;
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

        public static DbModel getDbContext()
        {
            dbContext = dbContext ?? GlobalVariables.getDbContext();
            return dbContext;
        }
    }
}
