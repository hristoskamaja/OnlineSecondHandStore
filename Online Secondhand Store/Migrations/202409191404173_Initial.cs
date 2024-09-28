namespace Online_Secondhand_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Image", c => c.String());
            AddColumn("dbo.Clothings", "Image", c => c.String());
            AddColumn("dbo.ComputerAndITEquipments", "Image", c => c.String());
            AddColumn("dbo.ElectricalAppliances", "Image", c => c.String());
            AddColumn("dbo.Furnitures", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Furnitures", "Image");
            DropColumn("dbo.ElectricalAppliances", "Image");
            DropColumn("dbo.ComputerAndITEquipments", "Image");
            DropColumn("dbo.Clothings", "Image");
            DropColumn("dbo.Cars", "Image");
        }
    }
}
