namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateInitialSupervisor : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[Employees] ([Name], [DateStarted], [DateEnded], [Qualification], [DepartmentId], [DesignationId], [Gender], [Discriminator], [UserId], [SupervisorId]) VALUES (N'Name', N'2018-03-08 00:00:00', NULL, N'IV', 1, 1, N'male', N'Supervisor', N'9c2ada82-7c4f-44d0-aefc-d06cb2c988e2', NULL)
");
        }
        
        public override void Down()
        {
        }
    }
}
