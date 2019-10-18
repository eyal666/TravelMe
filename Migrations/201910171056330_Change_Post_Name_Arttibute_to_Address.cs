namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Post_Name_Arttibute_to_Address : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Places", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Places", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Places", "Address");
        }
    }
}
