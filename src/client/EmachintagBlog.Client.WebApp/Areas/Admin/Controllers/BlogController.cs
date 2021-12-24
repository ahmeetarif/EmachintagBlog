using EmachintagBlog.Client.WebApp.Common.Helpers;
using EmachintagBlog.Client.WebApp.Data;
using EmachintagBlog.Client.WebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmachintagBlog.Client.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : BaseAdminController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BlogController(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
            : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        // GET : Admin/Blog
        [HttpGet]
        public IActionResult Index()
        {
            var blogs = _applicationDbContext.Blogs
                .OrderByDescending(x => x.CreatedAt);

            if (blogs.Count() > 0)
            {
                return View(new List<Blogs>(blogs));
            }

            return View(new List<Blogs>());
        }

        // GET : Admin/Blog/Create
        [HttpGet]
        public IActionResult Create() => View();

        // POST : Admin/Blog/Create
        [HttpPost]
        public IActionResult Create(IFormFile formFile, Blogs blog)
        {
            if (ModelState.IsValid)
            {
                string filePath = string.Empty;

                if (formFile != null && formFile.Length > 0)
                {
                    filePath = UploadImageHelper.UploadedFile(_webHostEnvironment, formFile, "Blogs");
                }

                blog.ImagePath = filePath;
                blog.CreatedAt = System.DateTime.Now;
                _applicationDbContext.Blogs.Add(blog);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "Blog");
            }

            return View();
        }

        // GET : Admin/Blog/Edit/{id}
        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }

            Blogs blog = _applicationDbContext.Blogs.Where(x => x.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return new NotFoundResult();
            }

            return View(blog);
        }

        // POST : Admin/Blog/Edit/{id}
        [HttpPost]
        public IActionResult Edit(IFormFile formFile, Blogs blog)
        {
            if (ModelState.IsValid)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    blog.ImagePath = UploadImageHelper.UploadedFile(_webHostEnvironment, formFile, "Blogs");
                }

                blog.UpdatedAt = System.DateTime.Now;

                _applicationDbContext.Entry(blog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "Blog");
            }

            return View(blog);
        }

        // GET: Admin/Blog/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }
            Blogs blog = _applicationDbContext.Blogs.Where(x => x.Id == id).FirstOrDefault();
            if (blog == null)
            {
                return new NotFoundResult();
            }
            return View(blog);
        }

        // POST: Admin/Blog/Delete/5
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            Blogs blog = _applicationDbContext.Blogs.Where(x => x.Id == id).FirstOrDefault();

            if (blog == null)
            {
                return new NotFoundResult();
            }

            _applicationDbContext.Blogs.Remove(blog);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "Blog");
        }
    }
}