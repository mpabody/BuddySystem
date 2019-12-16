namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedUserRoleFromApplicationUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApplicationUser", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.Int(nullable: false));
        }
    }
}
