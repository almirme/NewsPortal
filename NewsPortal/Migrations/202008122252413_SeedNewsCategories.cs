namespace NewsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedNewsCategories : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[NewsCategories] ([Id], [Name]) VALUES (1, N'Politics')
                INSERT INTO [dbo].[NewsCategories] ([Id], [Name]) VALUES (2, N'Business')
                INSERT INTO [dbo].[NewsCategories] ([Id], [Name]) VALUES (3, N'Sport')
                INSERT INTO [dbo].[NewsCategories] ([Id], [Name]) VALUES (4, N'Technology')
                INSERT INTO [dbo].[NewsCategories] ([Id], [Name]) VALUES (5, N'Lifestyle')");
        }
        
        public override void Down()
        {
        }
    }
}
