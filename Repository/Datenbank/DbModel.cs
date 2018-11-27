
using Repository.SpielerEntity;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Repository.Migrations;

namespace Repository.Datenbank
{
    public  class DbModel : DbContext
    {

        public virtual DbSet<Player> Players { get; set; }

        public DbModel(String inConncectionString) :base( new FbConnection(inConncectionString),true)
        {
            this.Database.CreateIfNotExists();
            //

        }

        public DbModel() : base()
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbModel, Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
