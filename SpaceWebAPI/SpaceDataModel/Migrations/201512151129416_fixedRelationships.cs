namespace SpaceDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubTopics", "Story_ID", "dbo.Stories");
            DropForeignKey("dbo.Topics", "Story_ID", "dbo.Stories");
            DropForeignKey("dbo.Stories", "StoryType_ID", "dbo.StoryTypes");
            DropIndex("dbo.Stories", new[] { "StoryType_ID" });
            DropIndex("dbo.SubTopics", new[] { "Story_ID" });
            DropIndex("dbo.Topics", new[] { "Story_ID" });
            RenameColumn(table: "dbo.Stories", name: "StoryType_ID", newName: "StoryTypeID");
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
            
            AlterColumn("dbo.Stories", "StoryTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Stories", "StoryTypeID");
            AddForeignKey("dbo.Stories", "StoryTypeID", "dbo.StoryTypes", "ID", cascadeDelete: true);
            DropColumn("dbo.SubTopics", "Story_ID");
            DropColumn("dbo.Topics", "Story_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "Story_ID", c => c.Int());
            AddColumn("dbo.SubTopics", "Story_ID", c => c.Int());
            DropForeignKey("dbo.Stories", "StoryTypeID", "dbo.StoryTypes");
            DropForeignKey("dbo.TopicStories", "Story_ID", "dbo.Stories");
            DropForeignKey("dbo.TopicStories", "Topic_ID", "dbo.Topics");
            DropIndex("dbo.TopicStories", new[] { "Story_ID" });
            DropIndex("dbo.TopicStories", new[] { "Topic_ID" });
            DropIndex("dbo.Stories", new[] { "StoryTypeID" });
            AlterColumn("dbo.Stories", "StoryTypeID", c => c.Int());
            DropTable("dbo.TopicStories");
            RenameColumn(table: "dbo.Stories", name: "StoryTypeID", newName: "StoryType_ID");
            CreateIndex("dbo.Topics", "Story_ID");
            CreateIndex("dbo.SubTopics", "Story_ID");
            CreateIndex("dbo.Stories", "StoryType_ID");
            AddForeignKey("dbo.Stories", "StoryType_ID", "dbo.StoryTypes", "ID");
            AddForeignKey("dbo.Topics", "Story_ID", "dbo.Stories", "ID");
            AddForeignKey("dbo.SubTopics", "Story_ID", "dbo.Stories", "ID");
        }
    }
}
