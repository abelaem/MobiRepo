namespace Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Quantity = c.Single(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        UOMId = c.Int(nullable: false),
                        ProducsCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProducsCategories", t => t.ProducsCategory_Id)
                .ForeignKey("dbo.ProducsCategories", t => t.UOMId, cascadeDelete: true)
                .Index(t => t.UOMId)
                .Index(t => t.ProducsCategory_Id);
           
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UOMId", "dbo.ProducsCategories");
            DropForeignKey("dbo.Products", "ProducsCategory_Id", "dbo.ProducsCategories");
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Products", new[] { "ProducsCategory_Id" });
            DropIndex("dbo.Products", new[] { "UOMId" });
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.UOMs");
            DropTable("dbo.Products");
            DropTable("dbo.ProducsCategories");
            DropTable("dbo.Movies");
            DropTable("dbo.Genres");
        }
    }
}
