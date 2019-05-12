namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'Admin')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'deb8089e-4390-43dd-8afc-a6062a3b72a6', N'Agent')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2a7a8f28-db52-40ef-9910-32fbd08716b3', N'Specialist')

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Name], [IsActive]) VALUES (N'9c2ada82-7c4f-44d0-aefc-d06cb2c988e2', N'admin@webshop.com', 0, N'AEtlxZGvKpg7bDN+SuMZvdUOWCH+k0Mv8MKFE30tIDjZVbGAXwHh8Yc98D7l9NOtlA==', N'208fd671-b33c-4bd0-a5d6-65a8861028c1', NULL, 0, 0, NULL, 1, 0, N'admin@webshop.com', NULL, NULL)

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9c2ada82-7c4f-44d0-aefc-d06cb2c988e2', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')
");
        }
        
        public override void Down()
        {
        }
    }
}
