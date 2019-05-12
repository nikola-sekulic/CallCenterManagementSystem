namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeviceSupplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceSuppliers",
                c => new
                    {
                        CompamyName = c.String(nullable: false, maxLength: 25),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CompamyName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeviceSuppliers");
        }
    }
}
