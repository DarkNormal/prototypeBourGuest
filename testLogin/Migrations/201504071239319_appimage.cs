namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.Restaurant", "appImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("bourguestMob.Restaurant", "appImage");
        }
    }
}
