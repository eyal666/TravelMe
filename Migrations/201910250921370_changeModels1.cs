namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.PlaceCatagories", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.PlaceCatagories", "PlaceID", "dbo.Places");
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.PlaceCatagories", new[] { "PlaceID" });
            DropIndex("dbo.PlaceCatagories", new[] { "Category_ID" });
            DropTable("dbo.Comments");
            DropTable("dbo.PlaceCatagories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlaceCatagories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PlaceID = c.Int(nullable: false),
                        CatagoryID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.PlaceCatagories", "Category_ID");
            CreateIndex("dbo.PlaceCatagories", "PlaceID");
            CreateIndex("dbo.Comments", "PostID");
            AddForeignKey("dbo.PlaceCatagories", "PlaceID", "dbo.Places", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PlaceCatagories", "Category_ID", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "PostID", "dbo.Posts", "ID", cascadeDelete: true);
        }
    }
}
