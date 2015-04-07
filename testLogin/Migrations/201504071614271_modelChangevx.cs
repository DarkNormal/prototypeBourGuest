namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChangevx : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.Restaurant", "appImage", c => c.String());
            AddColumn("bourguestMob.tableObjectBookings", "uzer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("bourguestMob.tableObjectBookings", "uzer");
            DropColumn("bourguestMob.Restaurant", "appImage");
        }
    }
}
