namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmployeeInReclamation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reclamations", "SpecialistId", "dbo.Employees");
            DropIndex("dbo.Reclamations", new[] { "SpecialistId" });
            DropColumn("dbo.Reclamations", "EmployeeId");
            DropColumn("dbo.Reclamations", "SpecialistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reclamations", "SpecialistId", c => c.Int(nullable: false));
            AddColumn("dbo.Reclamations", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reclamations", "SpecialistId");
            AddForeignKey("dbo.Reclamations", "SpecialistId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
