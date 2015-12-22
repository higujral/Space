namespace SpaceDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpaceDBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Content = c.String(),
                        StoryType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StoryTypes", t => t.StoryType_ID)
                .Index(t => t.StoryType_ID);
            
            CreateTable(
                "dbo.StoryFeedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoryID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
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
                "dbo.SubTopics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TopicID = c.Int(nullable: false),
                        Story_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .ForeignKey("dbo.Stories", t => t.Story_ID)
                .Index(t => t.TopicID)
                .Index(t => t.Story_ID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Story_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Stories", t => t.Story_ID)
                .Index(t => t.Story_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Story_ID", "dbo.Stories");
            DropForeignKey("dbo.SubTopics", "Story_ID", "dbo.Stories");
            DropForeignKey("dbo.SubTopics", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.Stories", "StoryType_ID", "dbo.StoryTypes");
            DropForeignKey("dbo.StoryFeedbacks", "StoryID", "dbo.Stories");
            DropIndex("dbo.Topics", new[] { "Story_ID" });
            DropIndex("dbo.SubTopics", new[] { "Story_ID" });
            DropIndex("dbo.SubTopics", new[] { "TopicID" });
            DropIndex("dbo.StoryFeedbacks", new[] { "StoryID" });
            DropIndex("dbo.Stories", new[] { "StoryType_ID" });
            DropTable("dbo.Topics");
            DropTable("dbo.SubTopics");
            DropTable("dbo.StoryTypes");
            DropTable("dbo.StoryFeedbacks");
            DropTable("dbo.Stories");
        }
    }
}
