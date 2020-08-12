namespace NewsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        PictureUrl = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsArticles");
        }
    }
}
