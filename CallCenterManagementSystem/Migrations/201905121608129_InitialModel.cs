namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateStarted = c.DateTime(nullable: false),
                        DateEnded = c.DateTime(),
                        Qualification = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        Gender = c.String(),
                        SupervisorId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        IsActive = c.Boolean(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.DeviceSuppliers",
                c => new
                    {
                        CompamyName = c.String(nullable: false, maxLength: 25),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CompamyName);
            
            CreateTable(
                "dbo.Reclamations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProblemDescription = c.String(nullable: false, maxLength: 255),
                        Status = c.String(nullable: false, maxLength: 50),
                        AgentId = c.Int(nullable: false),
                        SpecialistId = c.Int(nullable: false),
                        SoldDeviceId = c.Int(nullable: false),
                        ReclamationCreated = c.DateTime(nullable: false),
                        ReclamationEnded = c.DateTime(),
                        ReclamationTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AgentId, cascadeDelete: false)
                .ForeignKey("dbo.ReclamationTypes", t => t.ReclamationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SoldDevices", t => t.SoldDeviceId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.SpecialistId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.SpecialistId)
                .Index(t => t.SoldDeviceId)
                .Index(t => t.ReclamationTypeId);
            
            CreateTable(
                "dbo.ReclamationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reclamations", "SpecialistId", "dbo.Employees");
            DropForeignKey("dbo.Reclamations", "SoldDeviceId", "dbo.SoldDevices");
            DropForeignKey("dbo.SoldDevices", "DeviceSupplier_CompamyName", "dbo.DeviceSuppliers");
            DropForeignKey("dbo.SoldDevices", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Reclamations", "ReclamationTypeId", "dbo.ReclamationTypes");
            DropForeignKey("dbo.Reclamations", "AgentId", "dbo.Employees");
            DropForeignKey("dbo.CallHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.CallHistories", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SoldDevices", new[] { "DeviceSupplier_CompamyName" });
            DropIndex("dbo.SoldDevices", new[] { "BuyerId" });
            DropIndex("dbo.Reclamations", new[] { "ReclamationTypeId" });
            DropIndex("dbo.Reclamations", new[] { "SoldDeviceId" });
            DropIndex("dbo.Reclamations", new[] { "SpecialistId" });
            DropIndex("dbo.Reclamations", new[] { "AgentId" });
            DropIndex("dbo.CallHistories", new[] { "EmployeeId" });
            DropIndex("dbo.CallHistories", new[] { "BuyerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SoldDevices");
            DropTable("dbo.ReclamationTypes");
            DropTable("dbo.Reclamations");
            DropTable("dbo.DeviceSuppliers");
            DropTable("dbo.CallHistories");
            DropTable("dbo.Buyers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
        }
    }
}
