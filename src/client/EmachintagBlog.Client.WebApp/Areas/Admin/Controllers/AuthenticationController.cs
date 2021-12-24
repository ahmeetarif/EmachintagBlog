using EmachintagBlog.Client.WebApp.Data;
using EmachintagBlog.Client.WebApp.Models;
using EmachintagBlog.Client.WebApp.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmachintagBlog.Client.WebApp.Areas.Admin.Controllers
{
    public class AuthenticationController : BaseAdminController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationController(ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) : base(applicationDbContext)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var getUserDetail = await _userManager.FindByEmailAsync(loginVM.Email);

                if (getUserDetail == null)
                {
                    ViewBag.Error = "Kullanıcı bulunamadı!";
                    return View(loginVM);
                }

                await _signInManager.SignInAsync(getUserDetail, isPersistent: true);

                return RedirectToAction("Index", "Dashboard");
            }

            return View(loginVM);
        }
    }
}