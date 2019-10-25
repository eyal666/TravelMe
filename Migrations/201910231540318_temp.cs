namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "CategoryID");
            AddForeignKey("dbo.Posts", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropColumn("dbo.Posts", "CategoryID");
        }
    }
}
