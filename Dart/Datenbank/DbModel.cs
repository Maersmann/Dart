
using Dart.Entity.SpielerObjekte;
using Dart.Migrations;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dart.Datenbank
{
    public  class DbModel : DbContext
    {

        public virtual DbSet<Player> Players { get; set; }

        public DbModel(String inConncectionString) :base( new FbConnection(inConncectionString),true)
        {
            this.Database.CreateIfNotExists();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbModel, Configuration>());

        }

        public DbModel() : base()
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
