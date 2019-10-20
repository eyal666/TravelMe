namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_postsID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "PostsIdList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "PostsIdList");
        }
    }
}
