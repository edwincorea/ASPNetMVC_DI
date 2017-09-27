using MVCDI.Models;
using System.Web.Mvc;

namespace MVCDI.Controllers
{
    public class BaseController: Controller
    {
        protected readonly IUnitOfWorkManager UnitOfWorkManager;
        // GET: Base
        public BaseController(IUnitOfWorkManager unitOfWorkManager)
        {
            UnitOfWorkManager = unitOfWorkManager;
        }
    }
}