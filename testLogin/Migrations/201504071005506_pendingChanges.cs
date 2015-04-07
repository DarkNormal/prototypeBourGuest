namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.Restaurant", "ImageName", c => c.String());
            AddColumn("bourguestMob.tableObjectBookings", "userID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("bourguestMob.tableObjectBookings", "userID");
            DropColumn("bourguestMob.Restaurant", "ImageName");
        }
    }
}
