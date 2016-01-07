namespace SpaceDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                        StoryTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StoryTypes", t => t.StoryTypeID, cascadeDelete: true)
                .Index(t => t.StoryTypeID);
            
            CreateTable(
                "dbo.StoryFeedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoryID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateLastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stories", t => t.StoryID, cascadeDelete: true)
                .Index(t => t.StoryID);
            
            CreateTable(
                "dbo.StoryTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 450),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "UniqueIndex");
            
            CreateTable(
                "dbo.SubTopics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TopicID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID);
            
            CreateTable(
                "dbo.TopicStories",
                c => new
                    {
                        Topic_ID = c.Int(nullable: false),
                        Story_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Topic_ID, t.Story_ID })
                .ForeignKey("dbo.Topics", t => t.Topic_ID, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.Story_ID, cascadeDelete: true)
                .Index(t => t.Topic_ID)
                .Index(t => t.Story_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubTopics", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.TopicStories", "Story_ID", "dbo.Stories");
            DropForeignKey("dbo.TopicStories", "Topic_ID", "dbo.Topics");
            DropForeignKey("dbo.Stories", "StoryTypeID", "dbo.StoryTypes");
            DropForeignKey("dbo.StoryFeedbacks", "StoryID", "dbo.Stories");
            DropIndex("dbo.TopicStories", new[] { "Story_ID" });
            DropIndex("dbo.TopicStories", new[] { "Topic_ID" });
            DropIndex("dbo.SubTopics", new[] { "TopicID" });
            DropIndex("dbo.Topics", "UniqueIndex");
            DropIndex("dbo.StoryFeedbacks", new[] { "StoryID" });
            DropIndex("dbo.Stories", new[] { "StoryTypeID" });
            DropTable("dbo.TopicStories");
            DropTable("dbo.SubTopics");
            DropTable("dbo.Topics");
            DropTable("dbo.StoryTypes");
            DropTable("dbo.StoryFeedbacks");
            DropTable("dbo.Stories");
        }
    }
}
