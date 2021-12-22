using EmachintagBlog.Client.WebApp.Common.Core;

namespace EmachintagBlog.Client.WebApp.Models
{
    public partial class Images : BaseEntity
    {
        public long BlogId { get; set; }

        public string ImagePath { get; set; }
        public bool IsCover { get; set; }
    }
}