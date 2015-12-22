namespace SpaceDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedColumnNameinStory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Stories", "Header");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stories", "Header", c => c.String());
            DropColumn("dbo.Stories", "Title");
        }
    }
}
