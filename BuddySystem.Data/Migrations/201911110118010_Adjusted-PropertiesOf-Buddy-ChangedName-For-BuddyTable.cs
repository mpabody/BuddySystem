namespace BuddySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustedPropertiesOfBuddyChangedNameForBuddyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buddy", "IsMale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buddy", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buddy", "Age");
            DropColumn("dbo.Buddy", "IsMale");
        }
    }
}
