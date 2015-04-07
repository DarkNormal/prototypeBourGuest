namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("bourguestMob.Restaurant", "vegan", c => c.Boolean(nullable: false));
            DropColumn("bourguestMob.Restaurant", "vegetarian");
        }
        
        public override void Down()
        {
            AddColumn("bourguestMob.Restaurant", "vegetarian", c => c.Boolean(nullable: false));
            DropColumn("bourguestMob.Restaurant", "vegan");
        }
    }
}
