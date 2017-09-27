using MVCDI.Models;
using System;
using System.Web.Mvc;

namespace MVCDI.Controllers
{
    public class ArticleController : BaseController
    {

        private readonly IArticleRepository articleRepository;

        public ArticleController(IUnitOfWorkManager unitOfWorkManager, IArticleRepository articleRepository)
            : base(unitOfWorkManager)
        {
            this.articleRepository = articleRepository;
        }

        // GET: Article
        public ActionResult Index()

        {
            return View();
        }

        // POST: Article
        [HttpPost]
        public void SaveArticle()
        {
            // Create an article
            using (var unitOfWork = this.UnitOfWorkManager.NewUnitOfWork())
            {
                this.articleRepository.Add(new Article()
                {
                    Id = Guid.NewGuid(),
                    Title = "Title Text",
                    Summary = "Summary Text",
                    ArticleContent = "Html content",
                    ViewCount = 0,
                    CreatedDate = DateTime.Now,
                    CreatedByUsername = "admin",
                    Tags = "mvc, unity, asp.net"
                });

                unitOfWork.Commit();
            }
        }
    }
}