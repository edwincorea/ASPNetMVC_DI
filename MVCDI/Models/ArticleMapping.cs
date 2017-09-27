using System.Data.Entity.ModelConfiguration;

namespace MVCDI.Models
{
    public class ArticleMapping : EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            this.HasKey(x => x.Id);
            this.ToTable("Articles"); // map to Articles table in database
        }
    }
}