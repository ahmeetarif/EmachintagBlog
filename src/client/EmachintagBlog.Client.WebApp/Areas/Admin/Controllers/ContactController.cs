using EmachintagBlog.Client.WebApp.Data;
using EmachintagBlog.Client.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmachintagBlog.Client.WebApp.Areas.Admin.Controllers
{
    public class ContactController : BaseAdminController
    {
        public ContactController(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        // GET : Admin/Contact
        [HttpGet]
        public IActionResult Index()
        {
            var contacts = _applicationDbContext.Contacts.OrderByDescending(x => x.CreatedAt);

            if (contacts.Count() > 0)
            {
                return View(new List<Contacts>(contacts));
            }

            return View(new List<Contacts>());
        }

        // GET : Admin/Contact/Detail/1
        [HttpGet]
        public IActionResult Detail(long? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }

            Contacts contact = _applicationDbContext.Contacts.Where(x => x.Id == id).FirstOrDefault();
            if (contact == null)
            {
                return new NotFoundResult();
            }

            return View(contact);
        }

    }
}