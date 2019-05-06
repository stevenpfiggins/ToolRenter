namespace ToolRenter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipment", "EquipmentTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipment", "EquipmentTypeId");
        }
    }
}
