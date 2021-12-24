using EmachintagBlog.Client.WebApp.Common;
using EmachintagBlog.Client.WebApp.Data;
using EmachintagBlog.Client.WebApp.Models;
using EmachintagBlog.Client.WebApp.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EmachintagBlog.Client.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly CurrentUser _currentUser;

        private static string COMMENT_ERROR_MESSAGE = null;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext applicationDbContext,
            CurrentUser currentUser)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
            _currentUser = currentUser;
        }

        public IActionResult Index()
        {
            var getBlogs = (from blog in _applicationDbContext.Blogs
                            select new BlogViewModel
                            {
                                CreatedAt = blog.CreatedAt,
                                Id = blog.Id,
                                ImagePath = blog.ImagePath,
                                LongDescription = blog.LongDescription,
                                ShortDescription = blog.ShortDescription,
                                Title = blog.Title,
                                TotalResponse = (from blogComment in _applicationDbContext.BlogComments where blogComment.BlogId == blog.Id select blogComment).Count()
                            }).OrderByDescending(x => x.CreatedAt).ToList();

            ViewBag.Blogs = getBlogs;
            ViewBag.About = _applicationDbContext.Abouts.FirstOrDefault();

            return View();
        }

        public IActionResult Detail(long id)
        {
            var getBlogById = (from blog in _applicationDbContext.Blogs
                               where blog.Id == id
                               select new { blog })
                               .FirstOrDefault();

            var getBlogResponses = _applicationDbContext.BlogComments
                .Where(x => x.BlogId == id)
                .Select(x => new BlogResponseViewModel
                {
                    BlogId = x.BlogId,
                    CommentMessage = x.CommentMessage,
                    CommentParentId = x.CommentParentId,
                    UserId = x.UserId,
                    UserName = (from user in _applicationDbContext.Users where user.Id == x.UserId select user.UserName).FirstOrDefault(),
                    CreatedAt = x.CreatedAt.ToShortDateString(),
                    Type = (from user in _applicationDbContext.Users where user.Id == x.UserId select user.Type).FirstOrDefault() == Common.Enums.UserTypeEnum.ADMIN ? "ADMİN" : "USER"
                }).ToList();

            ViewBag.BlogComments = getBlogResponses;

            if (COMMENT_ERROR_MESSAGE != null)
            {
                ViewBag.CommentError = COMMENT_ERROR_MESSAGE;
            }

            return View(new BlogViewModel
            {
                CreatedAt = getBlogById.blog.CreatedAt,
                Id = getBlogById.blog.Id,
                ImagePath = getBlogById.blog.ImagePath,
                LongDescription = getBlogById.blog.LongDescription,
                ShortDescription = getBlogById.blog.ShortDescription,
                Title = getBlogById.blog.Title,
                TotalResponse = getBlogResponses.Count()
            });
        }

        [HttpPost]
        public IActionResult PostComment(string commentText, long blogId)
        {
            if (commentText != null && commentText != string.Empty)
            {
                try
                {
                    var blogComment = new BlogComments
                    {
                        BlogId = blogId,
                        CommentMessage = commentText,
                        CreatedAt = System.DateTime.Now,
                        UserId = _currentUser.UserId,
                        CreatedBy = _currentUser.UserId
                    };
                    _applicationDbContext.BlogComments.Add(blogComment);
                    _applicationDbContext.SaveChanges();
                }
                catch (System.Exception)
                {
                }

            }
            return RedirectToAction("Detail", new { id = blogId });
        }
    }
}