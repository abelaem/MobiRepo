namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reference = c.String(),
                        CreatedBy = c.String(),
                        PartnerId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        SalesTotal = c.Single(nullable: false),
                        SalesOrderLineId = c.Int(nullable: false),
                        Partner_Id = c.Byte(),
                        SalesOrderLine_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Partners", t => t.Partner_Id)
                .ForeignKey("dbo.SalesOrderLines", t => t.SalesOrderLine_Id)
                .Index(t => t.Partner_Id)
                .Index(t => t.SalesOrderLine_Id);
            
            CreateTable(
                "dbo.SalesOrderLines",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        ProducsCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProducsCategories", t => t.ProducsCategory_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProducsCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "SalesOrderLine_Id", "dbo.SalesOrderLines");
            DropForeignKey("dbo.SalesOrderLines", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SalesOrderLines", "ProducsCategory_Id", "dbo.ProducsCategories");
            DropForeignKey("dbo.Sales", "Partner_Id", "dbo.Partners");
            DropIndex("dbo.SalesOrderLines", new[] { "ProducsCategory_Id" });
            DropIndex("dbo.SalesOrderLines", new[] { "ProductId" });
            DropIndex("dbo.Sales", new[] { "SalesOrderLine_Id" });
            DropIndex("dbo.Sales", new[] { "Partner_Id" });
            DropTable("dbo.SalesOrderLines");
            DropTable("dbo.Sales");
            DropTable("dbo.Partners");
        }
    }
}
