namespace NewsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewsCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsCategories");
        }
    }
}
