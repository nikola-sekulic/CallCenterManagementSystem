namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDesignations : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Designations (Name) VALUES ('Supervisor')");
            Sql("INSERT INTO Designations (Name) VALUES ('Agent')");
            Sql("INSERT INTO Designations (Name) VALUES ('Specialist')");
        }
        
        public override void Down()
        {
        }
    }
}
