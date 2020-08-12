namespace NewsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName]) VALUES (N'99bed084-3c9b-4146-8881-cc2ec38d4d11', N'admin@abcdnews.com', 0, N'AAEheJFu707ZWNzNjZ3vdBZhSazppowECCrMzUovvIaHkGfLDkkLT8Wf6ujABQECNw==', N'2c86d5fb-a8a5-41ac-8bb3-4c33eaa052ec', NULL, 0, 0, NULL, 1, 0, N'admin@abcdnews.com', N'Admin', N'News')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'70299d45-848a-4e76-95aa-c247401a0264', N'CanAddNews')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'99bed084-3c9b-4146-8881-cc2ec38d4d11', N'70299d45-848a-4e76-95aa-c247401a0264')

");
        }
        
        public override void Down()
        {
        }
    }
}
