namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'40d7bcd0-0568-4814-b4f0-c49fced9d95b', N'admin@vidly.com', 0, N'ACpKi3VWqx2i4UvEbs55mupQHuaxouYyHzWmIoeRDlTDyBFAzFkR3sjNMsNn/f7dBA==', N'a67e1109-0d72-4a74-9aaa-aaf68a5a99cb', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8cc9e4ac-1d80-44d8-b5bb-2a69d6609af6', N'guest@vidly.com', 0, N'AJZsWi4KHpV6P0UZaGZ7VG3/xy5mxkTfzQTeofyrW3Nh6PSqo9d3I7J367yQ7fq9eQ==', N'5f69bb3a-2a2c-4390-847a-7a63930d407c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7a301077-abf3-49c2-9fdc-f5a2e9054213', N'Manager')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'40d7bcd0-0568-4814-b4f0-c49fced9d95b', N'7a301077-abf3-49c2-9fdc-f5a2e9054213')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
