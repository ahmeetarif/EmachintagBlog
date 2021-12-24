using EmachintagBlog.Client.WebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmachintagBlog.Client.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseAdminController : Controller
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        public BaseAdminController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}