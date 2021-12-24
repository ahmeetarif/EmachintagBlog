using System.ComponentModel.DataAnnotations;

namespace EmachintagBlog.Client.WebApp.ViewModels.Authentication
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Adınızı Giriniz!")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen kullanıcı adı belirleyiniz!")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen Mail Giriniz!")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir mail giriniz!")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lütfen şifrenizi giriniz!")]
        public string Password { get; set; }
    }
}