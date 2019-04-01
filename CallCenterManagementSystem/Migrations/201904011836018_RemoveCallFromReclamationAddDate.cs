namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCallFromReclamationAddDate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reclamations", "CallHistoryId", "dbo.CallHistories");
            DropIndex("dbo.Reclamations", new[] { "CallHistoryId" });
            AddColumn("dbo.Reclamations", "ReclamationCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reclamations", "ReclamationEnded", c => c.DateTime());
            DropColumn("dbo.Reclamations", "CallHistoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reclamations", "CallHistoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Reclamations", "ReclamationEnded");
            DropColumn("dbo.Reclamations", "ReclamationCreated");
            CreateIndex("dbo.Reclamations", "CallHistoryId");
            AddForeignKey("dbo.Reclamations", "CallHistoryId", "dbo.CallHistories", "Id", cascadeDelete: true);
        }
    }
}
