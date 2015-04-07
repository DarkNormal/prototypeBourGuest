namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingChanges1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("bourguestMob.Restaurant", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("bourguestMob.Restaurant", "ImageName", c => c.String());
        }
    }
}
