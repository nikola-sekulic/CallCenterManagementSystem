namespace CallCenterManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9c2ada82-7c4f-44d0-aefc-d06cb2c988e2', N'admin@webshop.com', 0, N'AEtlxZGvKpg7bDN+SuMZvdUOWCH+k0Mv8MKFE30tIDjZVbGAXwHh8Yc98D7l9NOtlA==', N'208fd671-b33c-4bd0-a5d6-65a8861028c1', NULL, 0, 0, NULL, 1, 0, N'admin@webshop.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f311fec2-2291-4d71-a28f-39616b76b3df', N'buyer@webshop.com', 0, N'AIwSO2tbawlWESTv0oR19P7uCfCNvZhGdwM344dxHPTo6RyFPlMjLMybYeLSFjD6UA==', N'd3e0e97b-7a75-449c-b157-560bc0aa94bd', NULL, 0, 0, NULL, 1, 0, N'buyer@webshop.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f311fec2-2291-4d71-a28f-39616b76b3df', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')");
        }
        
        public override void Down()
        {
        }
    }
}
