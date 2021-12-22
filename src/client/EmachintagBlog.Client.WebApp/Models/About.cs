using EmachintagBlog.Client.WebApp.Common.Core;

namespace EmachintagBlog.Client.WebApp.Models
{
    public partial class About : BaseEntity
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string FacebookLink { get; set; }
        public string YoutubeLink { get; set; }
    }
}