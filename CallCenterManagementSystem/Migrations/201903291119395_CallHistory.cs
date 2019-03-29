namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CallHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CallDate = c.DateTime(nullable: false),
                        BuyerId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.BuyerId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CallHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CallHistories", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.CallHistories", new[] { "EmployeeId" });
            DropIndex("dbo.CallHistories", new[] { "BuyerId" });
            DropTable("dbo.CallHistories");
        }
    }
}
