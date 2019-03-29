namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEmployeeGender : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Employees SET Gender ='Male'");
            Sql("UPDATE Employees SET Gender ='Female'");
        }
        
        public override void Down()
        {
        }
    }
}
