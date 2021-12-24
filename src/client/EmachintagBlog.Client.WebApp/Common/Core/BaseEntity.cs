using System;

namespace EmachintagBlog.Client.WebApp.Common.Core
{
    public partial class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}