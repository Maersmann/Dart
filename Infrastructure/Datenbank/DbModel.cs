
using infrastructure.SpielerEntity;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using infrastructure.Migrations;
using infrastructure.MatchEntity;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Infrastructure.OptionEntity;

namespace infrastructure.Datenbank
{
    public  class DbModel : DbContext
    {

        public virtual DbSet<Spieler> Players { get; set; }
        public virtual DbSet<Match> Matchs { get; set; }
        public virtual DbSet<MatchSpieler> MatchSpieler { get; set; }
        public virtual DbSet<Option> Options { get; set; }

        public DbModel(String inConncectionString) :base( inConncectionString)
        {
            this.Database.CreateIfNotExists();

            Database.SetInitializer<DbModel>(
                 new MigrateDatabaseToLatestVersion<DbModel, Configuration>(useSuppliedContext: true));
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
