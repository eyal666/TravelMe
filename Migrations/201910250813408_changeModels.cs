namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            AddColumn("dbo.Posts", "CategoryName", c => c.String(nullable: false));
            AddColumn("dbo.Posts", "Category_ID", c => c.Int());
            CreateIndex("dbo.Posts", "Category_ID");
            AddForeignKey("dbo.Posts", "Category_ID", "dbo.Categories", "ID");
            DropColumn("dbo.Categories", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Posts", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "Category_ID" });
            DropColumn("dbo.Posts", "Category_ID");
            DropColumn("dbo.Posts", "CategoryName");
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
