namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdforEmployees : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Reclamations", name: "Agent_Id", newName: "AgentId");
            RenameColumn(table: "dbo.Reclamations", name: "Specialist_Id", newName: "SpecialistId");
            RenameIndex(table: "dbo.Reclamations", name: "IX_Agent_Id", newName: "IX_AgentId");
            RenameIndex(table: "dbo.Reclamations", name: "IX_Specialist_Id", newName: "IX_SpecialistId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Reclamations", name: "IX_SpecialistId", newName: "IX_Specialist_Id");
            RenameIndex(table: "dbo.Reclamations", name: "IX_AgentId", newName: "IX_Agent_Id");
            RenameColumn(table: "dbo.Reclamations", name: "SpecialistId", newName: "Specialist_Id");
            RenameColumn(table: "dbo.Reclamations", name: "AgentId", newName: "Agent_Id");
        }
    }
}
