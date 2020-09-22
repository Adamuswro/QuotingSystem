namespace QuotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMoneyClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotes", "Price_Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Quotes", "Price_CurrencyType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotes", "Price_CurrencyType");
            DropColumn("dbo.Quotes", "Price_Value");
        }
    }
}
