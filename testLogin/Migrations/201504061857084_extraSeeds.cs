namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class extraSeeds : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.Reviews", "restID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("bourguestMob.Reviews", "restID");
        }
    }
}
