namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDepartment : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Name) VALUES ('General')");
            Sql("INSERT INTO Departments (Name) VALUES ('Part Time')");
        }
        
        public override void Down()
        {
        }
    }
}
