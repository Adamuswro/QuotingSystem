namespace QuotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        QuoteId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PN = c.Int(nullable: false),
                        Temp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Quotes");
        }
    }
}
