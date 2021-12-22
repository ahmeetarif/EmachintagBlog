using EmachintagBlog.Client.WebApp.Common.Core;
using System.Collections.Generic;

namespace EmachintagBlog.Client.WebApp.Models
{
    public partial class Blogs : BaseEntity
    {
        public Blogs()
        {
            BlogImages = new HashSet<Images>();
        }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public virtual ICollection<Images> BlogImages { get; set; }
    }
}