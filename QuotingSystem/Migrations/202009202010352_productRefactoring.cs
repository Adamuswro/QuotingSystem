namespace QuotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productRefactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "PN", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Temp", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "MinPN");
            DropColumn("dbo.Products", "MinTemp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "MinTemp", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "MinPN", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Temp");
            DropColumn("dbo.Products", "PN");
            DropColumn("dbo.Products", "Name");
        }
    }
}
