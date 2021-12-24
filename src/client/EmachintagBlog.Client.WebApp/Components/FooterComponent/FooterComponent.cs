using EmachintagBlog.Client.WebApp.Data;
using EmachintagBlog.Client.WebApp.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EmachintagBlog.Client.WebApp.Components
{
    public class FooterComponent : ViewComponent
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public FooterComponent(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var getBlogResponses = _applicationDbContext.BlogComments
                .OrderByDescending(x => x.CreatedAt)
                .Where(x => x.BlogId != 0)
                .Select(x => new BlogResponseViewModel
                {
                    BlogId = x.BlogId,
                    CommentMessage = x.CommentMessage,
                    CommentParentId = x.CommentParentId,
                    UserId = x.UserId,
                    UserName = (from user in _applicationDbContext.Users where user.Id == x.UserId select user.UserName).FirstOrDefault(),
                    CreatedAt = x.CreatedAt.ToShortDateString(),
                    Type = (from user in _applicationDbContext.Users where user.Id == x.UserId select user.Type).FirstOrDefault() == Common.Enums.UserTypeEnum.ADMIN ? "ADMİN" : "USER"
                }).Take(3).ToList();

            return View(getBlogResponses);
        }
    }
}