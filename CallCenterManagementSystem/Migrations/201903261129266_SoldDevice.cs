namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoldDevice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SoldDevices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        WarrantyStartDate = c.DateTime(nullable: false),
                        WarrantyEndDate = c.DateTime(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeviceSupplier_CompamyName = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.DeviceSuppliers", t => t.DeviceSupplier_CompamyName)
                .Index(t => t.BuyerId)
                .Index(t => t.DeviceSupplier_CompamyName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoldDevices", "DeviceSupplier_CompamyName", "dbo.DeviceSuppliers");
            DropForeignKey("dbo.SoldDevices", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.SoldDevices", new[] { "DeviceSupplier_CompamyName" });
            DropIndex("dbo.SoldDevices", new[] { "BuyerId" });
            DropTable("dbo.SoldDevices");
            DropTable("dbo.DeviceSupplierId");
        }
    }
}
