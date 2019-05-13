namespace ToolRenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "PhotoUpload", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipment", "PhotoUpload");
        }
    }
}
