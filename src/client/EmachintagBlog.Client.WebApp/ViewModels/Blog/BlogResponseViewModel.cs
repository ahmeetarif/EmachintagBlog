namespace EmachintagBlog.Client.WebApp.ViewModels.Blog
{
    public class BlogResponseViewModel
    {
        public long BlogId { get; set; }
        public long CommentParentId { get; set; }

        public string UserId { get; set; }
        public string CommentMessage { get; set; }

        public string UserName { get; set; }

        public string Type { get; set; }

        public string CreatedAt { get; set; }
    }
}