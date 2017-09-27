namespace MVCDI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Article : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Summary = c.String(),
                        ArticleContent = c.String(),
                        ViewCount = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedByUsername = c.String(),
                        Tags = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
