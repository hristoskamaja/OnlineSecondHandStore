namespace Online_Secondhand_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Condition", c => c.String());
            AddColumn("dbo.Cars", "Description", c => c.String());
            AddColumn("dbo.Clothings", "Condition", c => c.String());
            AddColumn("dbo.Clothings", "Description", c => c.String());
            AddColumn("dbo.ComputerAndITEquipments", "Condition", c => c.String());
            AddColumn("dbo.ComputerAndITEquipments", "Description", c => c.String());
            AddColumn("dbo.ElectricalAppliances", "Condition", c => c.String());
            AddColumn("dbo.ElectricalAppliances", "Description", c => c.String());
            AddColumn("dbo.Furnitures", "Condition", c => c.String());
            AddColumn("dbo.Furnitures", "Description", c => c.String());
            DropColumn("dbo.Cars", "IsUsed");
            DropColumn("dbo.Clothings", "IsUsed");
            DropColumn("dbo.ComputerAndITEquipments", "IsUsed");
            DropColumn("dbo.ElectricalAppliances", "IsUsed");
            DropColumn("dbo.Furnitures", "IsUsed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Furnitures", "IsUsed", c => c.Boolean(nullable: false));
            AddColumn("dbo.ElectricalAppliances", "IsUsed", c => c.Boolean(nullable: false));
            AddColumn("dbo.ComputerAndITEquipments", "IsUsed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clothings", "IsUsed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Cars", "IsUsed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Furnitures", "Description");
            DropColumn("dbo.Furnitures", "Condition");
            DropColumn("dbo.ElectricalAppliances", "Description");
            DropColumn("dbo.ElectricalAppliances", "Condition");
            DropColumn("dbo.ComputerAndITEquipments", "Description");
            DropColumn("dbo.ComputerAndITEquipments", "Condition");
            DropColumn("dbo.Clothings", "Description");
            DropColumn("dbo.Clothings", "Condition");
            DropColumn("dbo.Cars", "Description");
            DropColumn("dbo.Cars", "Condition");
        }
    }
}
