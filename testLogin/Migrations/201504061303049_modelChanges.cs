namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bourguestMob.Bookings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numTables = c.Int(nullable: false),
                        userID = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.Reviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numReviews = c.Double(nullable: false),
                        rating = c.Double(nullable: false),
                        reviews = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.tableObjectBookings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        day = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        tabObjID = c.Int(nullable: false),
                        time = c.Int(nullable: false),
                        depart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.UserReviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        restID = c.String(),
                        userID = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.Users",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("bourguestMob.Users");
            DropTable("bourguestMob.UserReviews");
            DropTable("bourguestMob.tableObjectBookings");
            DropTable("bourguestMob.Reviews");
            DropTable("bourguestMob.Bookings");
        }
    }
}
