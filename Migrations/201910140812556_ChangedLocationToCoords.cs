namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLocationToCoords : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Altitude", c => c.Double(nullable: false));
            AddColumn("dbo.Places", "Latitude", c => c.Double(nullable: false));
            DropColumn("dbo.Places", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Location", c => c.String(nullable: false));
            DropColumn("dbo.Places", "Latitude");
            DropColumn("dbo.Places", "Altitude");
        }
    }
}
