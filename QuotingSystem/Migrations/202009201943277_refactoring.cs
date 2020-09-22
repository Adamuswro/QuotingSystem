namespace QuotingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        MinPN = c.Int(nullable: false),
                        MinTemp = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            AddColumn("dbo.Quotes", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Quotes", "LastChangedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Quotes", "SelectedCustomer_CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Quotes", "SelectedProduct_ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quotes", "SelectedCustomer_CustomerId");
            CreateIndex("dbo.Quotes", "SelectedProduct_ProductId");
            AddForeignKey("dbo.Quotes", "SelectedCustomer_CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Quotes", "SelectedProduct_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            DropColumn("dbo.Quotes", "Name");
            DropColumn("dbo.Quotes", "PN");
            DropColumn("dbo.Quotes", "Temp");
            DropColumn("dbo.Quotes", "Price_Value");
            DropColumn("dbo.Quotes", "Price_CurrencyType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotes", "Price_CurrencyType", c => c.Int(nullable: false));
            AddColumn("dbo.Quotes", "Price_Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Quotes", "Temp", c => c.Int(nullable: false));
            AddColumn("dbo.Quotes", "PN", c => c.Int(nullable: false));
            AddColumn("dbo.Quotes", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Quotes", "SelectedProduct_ProductId", "dbo.Products");
            DropForeignKey("dbo.Quotes", "SelectedCustomer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Quotes", new[] { "SelectedProduct_ProductId" });
            DropIndex("dbo.Quotes", new[] { "SelectedCustomer_CustomerId" });
            DropColumn("dbo.Quotes", "SelectedProduct_ProductId");
            DropColumn("dbo.Quotes", "SelectedCustomer_CustomerId");
            DropColumn("dbo.Quotes", "LastChangedDate");
            DropColumn("dbo.Quotes", "CreationDate");
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
