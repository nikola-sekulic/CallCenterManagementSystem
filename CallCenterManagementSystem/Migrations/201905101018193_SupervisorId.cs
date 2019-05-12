namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupervisorId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "SupervisorId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "SupervisorId1", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "SupervisorId" });
            DropIndex("dbo.Employees", new[] { "SupervisorId1" });
            DropColumn("dbo.Employees", "SupervisorId");
            RenameColumn(table: "dbo.Employees", name: "SupervisorId1", newName: "SupervisorId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Employees", name: "SupervisorId", newName: "SupervisorId1");
            AddColumn("dbo.Employees", "SupervisorId", c => c.Int());
            CreateIndex("dbo.Employees", "SupervisorId1");
            CreateIndex("dbo.Employees", "SupervisorId");
            AddForeignKey("dbo.Employees", "SupervisorId1", "dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "SupervisorId", "dbo.Employees", "Id");
        }
    }
}
