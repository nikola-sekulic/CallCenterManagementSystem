namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeySupervisorId : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "SupervisorId");
            AddForeignKey("dbo.Employees", "SupervisorId", "dbo.Employees","Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SupervisorId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "SupervisorId" });
        }
    }
}
