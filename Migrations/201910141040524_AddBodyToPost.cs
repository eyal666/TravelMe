namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBodyToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Body");
        }
    }
}
