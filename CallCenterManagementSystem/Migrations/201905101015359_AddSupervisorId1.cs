namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSupervisorId1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Employees", "SupervisorId1", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("Employees", "SupervisorId1");

        }
    }
}
