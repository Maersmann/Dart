namespace infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                {
                    ID = c.Int(nullable: false),
                    Legs = c.Int(nullable: false),
                    Sets = c.Int(nullable: false),
                    PunktZahl = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.MatchSpieler",
                c => new
                {
                    ID = c.Int(nullable: false),
                    SpielerID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Spieler", t => t.SpielerID, cascadeDelete: true, name:"FK_SpielerID")
                .Index(t => t.SpielerID);

            Sql("CREATE SEQUENCE GEN_MATCH_ID");
            Sql("CREATE SEQUENCE GEN_MATCHPLAYER_ID");

            Sql("CREATE trigger match_bi0 for \"Match\" " +
                 "active before insert position 0 " +
                    "AS " +
                    "begin " +
                        "if ((new.id IS NULL) or(new.id = 0)) then " +
                            "new.id = NEXT VALUE FOR GEN_MATCH_ID;" +
                    "end");

            Sql("CREATE trigger matchspieler_bi0 for \"MatchSpieler\" " +
                "active before insert position 0 " +
                    "AS " +
                    "begin " +
                        "if ((new.id IS NULL) or(new.id = 0)) then " +
                            "new.id = NEXT VALUE FOR GEN_MATCHPLAYER_ID;" +
                    "end");
        }

        public override void Down()
        {
            Sql("DROP TRIGGER match_bi0");
            Sql("DROP SEQUENCE GEN_MATCH_ID");
            Sql("DROP TRIGGER matchspieler_bi0");
            Sql("DROP SEQUENCE GEN_MATCHPLAYER_ID");
            DropForeignKey("dbo.MatchSpieler", "FK_SpielerID");
            DropIndex("dbo.MatchSpieler", new[] { "SpielerID" });
            DropTable("dbo.MatchSpieler");
            DropTable("dbo.Match");
        }
    }
}