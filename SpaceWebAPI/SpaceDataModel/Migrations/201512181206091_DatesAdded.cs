namespace SpaceDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stories", "DateLastModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.StoryFeedbacks", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.StoryFeedbacks", "DateLastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoryFeedbacks", "DateLastModified");
            DropColumn("dbo.StoryFeedbacks", "DateCreated");
            DropColumn("dbo.Stories", "DateLastModified");
            DropColumn("dbo.Stories", "DateCreated");
        }
    }
}
