namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsApprovedNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buddy", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Buddy", "IsVolunteer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Buddy", "IsVolunteer", c => c.Boolean(nullable: false));
            DropColumn("dbo.Buddy", "IsApproved");
        }
    }
}
