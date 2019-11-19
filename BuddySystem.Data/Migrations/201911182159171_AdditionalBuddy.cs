namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalBuddy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalBuddy",
                c => new
                    {
                        AdditionalBuddyId = c.Int(nullable: false, identity: true),
                        BuddyId = c.Int(nullable: false),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdditionalBuddyId)
                .ForeignKey("dbo.Buddy", t => t.BuddyId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.BuddyId)
                .Index(t => t.TripId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdditionalBuddy", "TripId", "dbo.Trip");
            DropForeignKey("dbo.AdditionalBuddy", "BuddyId", "dbo.Buddy");
            DropIndex("dbo.AdditionalBuddy", new[] { "TripId" });
            DropIndex("dbo.AdditionalBuddy", new[] { "BuddyId" });
            DropTable("dbo.AdditionalBuddy");
        }
    }
}
