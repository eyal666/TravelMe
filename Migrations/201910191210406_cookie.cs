namespace TravelMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cookie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cooks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UID = c.String(),
                        PID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cooks");
        }
    }
}
