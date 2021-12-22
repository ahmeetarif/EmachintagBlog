namespace EmachintagBlog.Client.WebApp.Models
{
    using EmachintagBlog.Client.WebApp.Common.Enums;
    using Microsoft.AspNetCore.Identity;

    public partial class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public UserTypeEnum Type { get; set; }
    }
}