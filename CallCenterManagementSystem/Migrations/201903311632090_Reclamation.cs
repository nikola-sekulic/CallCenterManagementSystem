namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reclamation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProblemDescription = c.String(nullable: false, maxLength: 255),
                        Status = c.String(nullable: false, maxLength: 50),
                        EmployeeId = c.Int(nullable: false),
                        SpecialistId = c.Int(nullable: false),
                        SoldDeviceId = c.Int(nullable: false),
                        CallHistoryId = c.Int(nullable: false),
                        ReclamationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CallHistories", t => t.CallHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.SpecialistId, cascadeDelete: false)
                .ForeignKey("dbo.ReclamationTypes", t => t.ReclamationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SoldDevices", t => t.SoldDeviceId, cascadeDelete: false)
                .Index(t => t.SpecialistId)
                .Index(t => t.SoldDeviceId)
                .Index(t => t.CallHistoryId)
                .Index(t => t.ReclamationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamations", "SoldDeviceId", "dbo.SoldDevices");
            DropForeignKey("dbo.Reclamations", "ReclamationTypeId", "dbo.ReclamationTypes");
            DropForeignKey("dbo.Reclamations", "SpecialistId", "dbo.Employees");
            DropForeignKey("dbo.Reclamations", "CallHistoryId", "dbo.CallHistories");
            DropIndex("dbo.Reclamations", new[] { "ReclamationTypeId" });
            DropIndex("dbo.Reclamations", new[] { "CallHistoryId" });
            DropIndex("dbo.Reclamations", new[] { "SoldDeviceId" });
            DropIndex("dbo.Reclamations", new[] { "SpecialistId" });
            DropTable("dbo.Reclamations");
        }
    }
}
