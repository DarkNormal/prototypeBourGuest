namespace testLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableNameChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "bourguestMob.Floorplan",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        height = c.Int(nullable: false),
                        width = c.Int(nullable: false),
                        numObjects = c.Int(nullable: false),
                        restID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.Restaurant",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        restaurantName = c.String(nullable: false),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                        wheelchair = c.Boolean(nullable: false),
                        vegetarian = c.Boolean(nullable: false),
                        type1 = c.String(nullable: false),
                        type2 = c.String(),
                        type3 = c.String(),
                        bio = c.String(nullable: false),
                        openClose = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        phoneNum = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.WebRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "bourguestMob.WebUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("bourguestMob.WebRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("bourguestMob.WebUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "bourguestMob.tableObject",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        xcoord = c.Int(nullable: false),
                        ycoord = c.Int(nullable: false),
                        objType = c.Int(nullable: false),
                        available = c.Boolean(nullable: false),
                        floorplanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "bourguestMob.WebUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "bourguestMob.WebUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("bourguestMob.WebUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "bourguestMob.WebUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("bourguestMob.WebUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("bourguestMob.WebUserRoles", "UserId", "bourguestMob.WebUsers");
            DropForeignKey("bourguestMob.WebUserLogins", "UserId", "bourguestMob.WebUsers");
            DropForeignKey("bourguestMob.WebUserClaims", "UserId", "bourguestMob.WebUsers");
            DropForeignKey("bourguestMob.WebUserRoles", "RoleId", "bourguestMob.WebRoles");
            DropIndex("bourguestMob.WebUserLogins", new[] { "UserId" });
            DropIndex("bourguestMob.WebUserClaims", new[] { "UserId" });
            DropIndex("bourguestMob.WebUsers", "UserNameIndex");
            DropIndex("bourguestMob.WebUserRoles", new[] { "RoleId" });
            DropIndex("bourguestMob.WebUserRoles", new[] { "UserId" });
            DropIndex("bourguestMob.WebRoles", "RoleNameIndex");
            DropTable("bourguestMob.WebUserLogins");
            DropTable("bourguestMob.WebUserClaims");
            DropTable("bourguestMob.WebUsers");
            DropTable("bourguestMob.tableObject");
            DropTable("bourguestMob.WebUserRoles");
            DropTable("bourguestMob.WebRoles");
            DropTable("bourguestMob.Restaurant");
            DropTable("bourguestMob.Floorplan");
        }
    }
}
