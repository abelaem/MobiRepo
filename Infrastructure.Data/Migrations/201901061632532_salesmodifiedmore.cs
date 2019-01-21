namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salesmodifiedmore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalesOrderLines", "SaleId", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesOrderLines", "SaleId");
            AddForeignKey("dbo.SalesOrderLines", "SaleId", "dbo.Sales", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrderLines", "SaleId", "dbo.Sales");
            DropIndex("dbo.SalesOrderLines", new[] { "SaleId" });
            DropColumn("dbo.SalesOrderLines", "SaleId");
        }
    }
}
