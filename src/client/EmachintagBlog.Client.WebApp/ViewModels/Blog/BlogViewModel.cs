using System;

namespace EmachintagBlog.Client.WebApp.ViewModels.Blog
{
    public partial class BlogViewModel
    {
        public long Id { get; set; }

        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }

        public int TotalResponse { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}