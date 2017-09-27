using System.Data.Entity;

namespace MVCDI.Models
{
    public class DomainDbContext: DbContext, IDomainDbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DomainDbContext()
            : base("MVCDI")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mappings
            modelBuilder.Configurations.Add(new ArticleMapping());

            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose()
        {

        }
    }
}