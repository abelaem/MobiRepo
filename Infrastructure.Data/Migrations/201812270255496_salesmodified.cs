namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salesmodified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "SalesOrderLine_Id", "dbo.SalesOrderLines");
            DropIndex("dbo.Sales", new[] { "SalesOrderLine_Id" });
            DropColumn("dbo.Sales", "SalesOrderLineId");
            DropColumn("dbo.Sales", "SalesOrderLine_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "SalesOrderLine_Id", c => c.Byte());
            AddColumn("dbo.Sales", "SalesOrderLineId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "SalesOrderLine_Id");
            AddForeignKey("dbo.Sales", "SalesOrderLine_Id", "dbo.SalesOrderLines", "Id");
        }
    }
}
