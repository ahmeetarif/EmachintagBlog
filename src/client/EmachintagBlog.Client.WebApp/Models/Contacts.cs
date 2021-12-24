using EmachintagBlog.Client.WebApp.Common.Core;

namespace EmachintagBlog.Client.WebApp.Models
{
    public partial class Contacts : BaseEntity
    {
        public string UserId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}