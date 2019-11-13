namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buddy",
                c => new
                    {
                        BuddyId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CurrentLocation = c.String(nullable: false),
                        IsVolunteer = c.Boolean(nullable: false),
                        IsMale = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuddyId);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        BuddyId = c.Int(nullable: false),
                        VolunteerId = c.Int(nullable: false),
                        StartLocation = c.String(nullable: false),
                        ProjectedEndLocation = c.String(nullable: false),
                        EndLocation = c.String(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        Buddy_BuddyId = c.Int(),
                    })
                .PrimaryKey(t => t.TripId)
                .ForeignKey("dbo.Buddy", t => t.BuddyId, cascadeDelete: false)
                .ForeignKey("dbo.Buddy", t => t.VolunteerId, cascadeDelete: false)                
                .Index(t => t.BuddyId)
                .Index(t => t.VolunteerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Trip", "Buddy_BuddyId", "dbo.Buddy");
            DropForeignKey("dbo.Trip", "VolunteerId", "dbo.Buddy");
            DropForeignKey("dbo.Trip", "BuddyId", "dbo.Buddy");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Trip", new[] { "Buddy_BuddyId" });
            DropIndex("dbo.Trip", new[] { "VolunteerId" });
            DropIndex("dbo.Trip", new[] { "BuddyId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Trip");
            DropTable("dbo.Buddy");
        }
    }
}
