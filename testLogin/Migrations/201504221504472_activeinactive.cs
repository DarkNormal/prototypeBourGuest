namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activeinactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.Floorplan", "active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("bourguestMob.Floorplan", "active");
        }
    }
}
