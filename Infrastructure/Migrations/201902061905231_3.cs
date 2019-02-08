namespace infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Option",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        LegZumSet = c.Int(nullable: false),
                        SetZumSieg = c.Int(nullable: false),
                        Punktzahl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MatchSpieler", "MatchID", c => c.Int(nullable: false));
            CreateIndex("dbo.MatchSpieler", "MatchID");
            AddForeignKey("dbo.MatchSpieler", "MatchID", "dbo.Match", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchSpieler", "MatchID", "dbo.Match");
            DropIndex("dbo.MatchSpieler", new[] { "MatchID" });
            DropColumn("dbo.MatchSpieler", "MatchID");
            DropTable("dbo.Option");
        }
    }
}
