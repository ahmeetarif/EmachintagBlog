using EmachintagBlog.Client.WebApp.Common.Core;

namespace EmachintagBlog.Client.WebApp.Models
{
    public partial class BlogComments : BaseEntity
    {
        public long BlogId { get; set; }
        public long CommentParentId { get; set; }

        public string UserId { get; set; }
        public string CommentMessage { get; set; }
    }
}