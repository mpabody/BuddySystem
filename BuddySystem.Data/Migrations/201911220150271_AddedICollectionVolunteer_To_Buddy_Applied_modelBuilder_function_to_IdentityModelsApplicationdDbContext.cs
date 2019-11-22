namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedICollectionVolunteer_To_Buddy_Applied_modelBuilder_function_to_IdentityModelsApplicationdDbContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trip", "Buddy_BuddyId", "dbo.Buddy");
            DropForeignKey("dbo.Trip", "BuddyId", "dbo.Buddy");
            DropForeignKey("dbo.Trip", "VolunteerId", "dbo.Buddy");
            DropIndex("dbo.Trip", new[] { "Buddy_BuddyId" });
            AddForeignKey("dbo.Trip", "BuddyId", "dbo.Buddy", "BuddyId");
            AddForeignKey("dbo.Trip", "VolunteerId", "dbo.Buddy", "BuddyId");
            DropColumn("dbo.Trip", "Buddy_BuddyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trip", "Buddy_BuddyId", c => c.Int());
            DropForeignKey("dbo.Trip", "VolunteerId", "dbo.Buddy");
            DropForeignKey("dbo.Trip", "BuddyId", "dbo.Buddy");
            CreateIndex("dbo.Trip", "Buddy_BuddyId");
            AddForeignKey("dbo.Trip", "VolunteerId", "dbo.Buddy", "BuddyId", cascadeDelete: true);
            AddForeignKey("dbo.Trip", "BuddyId", "dbo.Buddy", "BuddyId", cascadeDelete: true);
            AddForeignKey("dbo.Trip", "Buddy_BuddyId", "dbo.Buddy", "BuddyId");
        }
    }
}
