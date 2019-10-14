namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_altitude_to_longtitude : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Longtitude", c => c.Double(nullable: false));
            DropColumn("dbo.Places", "Longtitude");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Longtitude", c => c.Double(nullable: false));
            DropColumn("dbo.Places", "Longtitude");
        }
    }
}
