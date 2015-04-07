namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.tableObjectBookings", "uzer", c => c.String());
            DropColumn("bourguestMob.tableObjectBookings", "userID");
        }
        
        public override void Down()
        {
            AddColumn("bourguestMob.tableObjectBookings", "userID", c => c.String());
            DropColumn("bourguestMob.tableObjectBookings", "uzer");
        }
    }
}
