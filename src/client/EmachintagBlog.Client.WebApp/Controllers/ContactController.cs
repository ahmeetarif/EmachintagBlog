using EmachintagBlog.Client.WebApp.Data;
using EmachintagBlog.Client.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmachintagBlog.Client.WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ContactController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.About = _applicationDbContext.Abouts.FirstOrDefault();
            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(Contacts contacts)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    _applicationDbContext.Contacts.Add(contacts);
                    _applicationDbContext.SaveChanges();

                    return RedirectToAction("Index", "Contact");
                }
                catch (System.Exception)
                {
                    return RedirectToAction("Index", "Contact");
                }

            }

            return View("Index", contacts);
        }

    }
}
