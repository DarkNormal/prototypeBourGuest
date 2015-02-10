namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Floorplan",
                c => new
                    {
                        FloorplanID = c.Int(nullable: false, identity: true),
                        height = c.Int(nullable: false),
                        width = c.Int(nullable: false),
                        numObjects = c.Int(nullable: false),
                        Restaurant_restaurantID = c.Int(),
                    })
                .PrimaryKey(t => t.FloorplanID)
                .ForeignKey("dbo.Restaurant", t => t.Restaurant_restaurantID)
                .Index(t => t.Restaurant_restaurantID);
            
            CreateTable(
                "dbo.tableObject",
                c => new
                    {
                        tableObjectID = c.Int(nullable: false, identity: true),
                        xcoord = c.Int(nullable: false),
                        ycoord = c.Int(nullable: false),
                        objType = c.Int(nullable: false),
                        available = c.Boolean(nullable: false),
                        FloorplanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tableObjectID)
                .ForeignKey("dbo.Floorplan", t => t.FloorplanID, cascadeDelete: true)
                .Index(t => t.FloorplanID);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        restaurantID = c.Int(nullable: false, identity: true),
                        restaurantName = c.String(),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        wheelchair = c.Boolean(nullable: false),
                        vegetarian = c.Boolean(nullable: false),
                        type = c.String(),
                        bio = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.restaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Floorplan", "Restaurant_restaurantID", "dbo.Restaurant");
            DropForeignKey("dbo.tableObject", "FloorplanID", "dbo.Floorplan");
            DropIndex("dbo.tableObject", new[] { "FloorplanID" });
            DropIndex("dbo.Floorplan", new[] { "Restaurant_restaurantID" });
            DropTable("dbo.Restaurant");
            DropTable("dbo.tableObject");
            DropTable("dbo.Floorplan");
        }
    }
}
