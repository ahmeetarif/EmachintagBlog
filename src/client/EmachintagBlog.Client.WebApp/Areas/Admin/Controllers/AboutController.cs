using EmachintagBlog.Client.WebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using EmachintagBlog.Client.WebApp.Models;
using EmachintagBlog.Client.WebApp.Common.Helpers;

namespace EmachintagBlog.Client.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : BaseAdminController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutController(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
            : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET : Admin/About
        [HttpGet]
        public IActionResult Index()
        {
            var about = _applicationDbContext.Abouts.FirstOrDefault();

            return View(about);
        }

        // GET : Admin/About/Create
        [HttpGet]
        public IActionResult Create() => View();

        // POST : Admin/About/Create
        [HttpPost]
        public IActionResult Create(IFormFile formFile, About about)
        {
            if (ModelState.IsValid)
            {
                if (_applicationDbContext.Abouts.Count() > 0)
                {
                    return RedirectToAction("Index", "About");
                }

                if (formFile != null && formFile.Length > 0)
                {
                    about.ImagePath = UploadImageHelper.UploadedFile(_webHostEnvironment, formFile, "Abouts");
                }

                about.CreatedAt = System.DateTime.Now;
                _applicationDbContext.Abouts.Add(about);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "About");
            }

            return View();
        }

        // GET : Admin/About/Edit/{id}
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }

            About about = _applicationDbContext.Abouts.Where(x => x.Id == id).FirstOrDefault();
            if (about == null)
            {
                return new NotFoundResult();
            }

            return View(about);
        }

        // POST : Admin/About/Edit/{id}
        [HttpPost]
        public IActionResult Edit(IFormFile formFile, About about)
        {
            if (ModelState.IsValid)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    about.ImagePath = UploadImageHelper.UploadedFile(_webHostEnvironment, formFile, "Abouts");
                }
                about.UpdatedAt = System.DateTime.Now;
                _applicationDbContext.Entry(about).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "About");
            }

            return View(about);
        }

        // GET: Admin/About/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }
            About about = _applicationDbContext.Abouts.Where(x => x.Id == id).FirstOrDefault();
            if (about == null)
            {
                return new NotFoundResult();
            }
            return View(about);
        }

        // POST: Admin/About/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            About about = _applicationDbContext.Abouts.Where(x => x.Id == id).FirstOrDefault();

            if (about == null)
            {
                return new NotFoundResult();
            }

            _applicationDbContext.Abouts.Remove(about);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "About");
        }
    }
}