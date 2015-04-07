namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("bourguestMob.Restaurant", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("bourguestMob.Restaurant", "Email", c => c.String(nullable: false));
        }
    }
}
