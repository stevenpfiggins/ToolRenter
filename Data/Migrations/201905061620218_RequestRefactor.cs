namespace ToolRenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestRefactor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Request", "EquipmentId", c => c.Int(nullable: false));
            DropColumn("dbo.Request", "EquipmentTypeRequested");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Request", "EquipmentTypeRequested", c => c.String(nullable: false));
            DropColumn("dbo.Request", "EquipmentId");
        }
    }
}
