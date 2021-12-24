using EmachintagBlog.Client.WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmachintagBlog.Client.WebApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AboutController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            var about = _applicationDbContext.Abouts.FirstOrDefault();
            return View(about);
        }

    }
}