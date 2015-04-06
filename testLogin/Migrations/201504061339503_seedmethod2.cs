namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedmethod2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "bourguestMob.Users", newName: "UsersTable");
        }
        
        public override void Down()
        {
            RenameTable(name: "bourguestMob.UsersTable", newName: "Users");
        }
    }
}
