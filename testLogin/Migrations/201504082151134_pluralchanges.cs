namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pluralchanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "bourguestMob.Floorplans", newName: "Floorplan");
            RenameTable(name: "bourguestMob.Restaurants", newName: "Restaurant");
            RenameTable(name: "bourguestMob.tableObjects", newName: "tableObject");
            RenameTable(name: "bourguestMob.UsersTables", newName: "UsersTable");
        }
        
        public override void Down()
        {
            RenameTable(name: "bourguestMob.UsersTable", newName: "UsersTables");
            RenameTable(name: "bourguestMob.tableObject", newName: "tableObjects");
            RenameTable(name: "bourguestMob.Restaurant", newName: "Restaurants");
            RenameTable(name: "bourguestMob.Floorplan", newName: "Floorplans");
        }
    }
}
