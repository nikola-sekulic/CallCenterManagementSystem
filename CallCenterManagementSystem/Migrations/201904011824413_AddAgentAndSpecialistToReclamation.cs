namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgentAndSpecialistToReclamation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reclamations", "Agent_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Reclamations", "Specialist_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Reclamations", "Agent_Id");
            CreateIndex("dbo.Reclamations", "Specialist_Id");
            AddForeignKey("dbo.Reclamations", "Agent_Id", "dbo.Employees", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Reclamations", "Specialist_Id", "dbo.Employees", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamations", "Specialist_Id", "dbo.Employees");
            DropForeignKey("dbo.Reclamations", "Agent_Id", "dbo.Employees");
            DropIndex("dbo.Reclamations", new[] { "Specialist_Id" });
            DropIndex("dbo.Reclamations", new[] { "Agent_Id" });
            DropColumn("dbo.Reclamations", "Specialist_Id");
            DropColumn("dbo.Reclamations", "Agent_Id");
        }
    }
}
