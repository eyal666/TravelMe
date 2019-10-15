namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altitude_Longtitude_PostsController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Longtitude", c => c.Double(nullable: false));
            DropColumn("dbo.Places", "Altitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Altitude", c => c.Double(nullable: false));
            DropColumn("dbo.Places", "Longtitude");
        }
    }
}
