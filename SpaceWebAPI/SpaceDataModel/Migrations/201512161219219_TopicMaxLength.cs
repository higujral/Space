namespace SpaceDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TopicMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Topics", "Name", c => c.String(maxLength: 450));
            CreateIndex("dbo.Topics", "Name", unique: true, name: "UniqueIndex");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Topics", "UniqueIndex");
            AlterColumn("dbo.Topics", "Name", c => c.String());
        }
    }
}
