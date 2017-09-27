using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MVCDI.Models
{
    public class ArticleRepository: IArticleRepository
    {
        private readonly DomainDbContext context;

        public ArticleRepository(IDomainDbContext context)
        {
            this.context = context as DomainDbContext;
        }

        public Article Get(Guid id)
        {
            return this.context.Articles.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Article> GetAll()
        {
            return this.context.Articles;
        }

        public Article Add(Article item)
        {
            this.context.Articles.Add(item);
            return item;
        }

        public void Update(Article item)
        {
            // Check there's not an object with same identifier already in context
            if (this.context.Articles.Local.Select(x => x.Id == item.Id).Any())
            {
                throw new ApplicationException("Object already exists in context");
            }
            this.context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Article item)
        {
            this.context.Articles.Remove(item);
        }
    }
}