namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_UserRole_to_ApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "UserRole");
        }
    }
}
