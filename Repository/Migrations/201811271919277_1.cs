namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Spitzname = c.String(nullable: false, maxLength: 250),
                        Nachname = c.String(maxLength: 250),
                        Voname = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);

            Sql("CREATE SEQUENCE GEN_PLAYER_ID");
            Sql("CREATE trigger player_bi0 for \"Player\" " +
                 "active before insert position 0 " +
                    "AS " +
                    "begin " +
                        "if ((new.id IS NULL) or(new.id = 0)) then " +
                            "new.id = NEXT VALUE FOR GEN_PLAYER_ID;" +
                    "end");

        }
        
        public override void Down()
        {
            Sql("DROP TRIGGER PLAYER_BI0");
            Sql("DROP SEQUENCE GEN_PLAYER_ID");
            DropTable("dbo.Player");
        }
    }
}
