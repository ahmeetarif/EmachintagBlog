using System.ComponentModel.DataAnnotations;

namespace EmachintagBlog.Client.WebApp.ViewModels.Authentication
{
    public partial class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Mail Giriniz!")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail giriniz!")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }
    }
}