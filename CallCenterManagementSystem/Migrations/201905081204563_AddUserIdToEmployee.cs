namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToEmployee : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Employees", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Employees", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Employees", name: "UserId", newName: "User_Id");
        }
    }
}
