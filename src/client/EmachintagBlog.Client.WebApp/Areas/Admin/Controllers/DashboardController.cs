using Microsoft.AspNetCore.Mvc;

namespace EmachintagBlog.Client.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}