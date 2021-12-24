using EmachintagBlog.Client.WebApp.Models;
using EmachintagBlog.Client.WebApp.ViewModels.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmachintagBlog.Client.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthenticationController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var getUserDetail = await _userManager.FindByEmailAsync(loginViewModel.Email);

                if (getUserDetail == null)
                {
                    ViewBag.Error = "Kullanıcı bulunamadı!";
                    return View(loginViewModel);
                }

                var checkPassword = await _userManager.CheckPasswordAsync(getUserDetail, loginViewModel.Password);

                if (!checkPassword)
                {
                    ViewBag.Error = "Şifre Yanlış!";
                    return View(loginViewModel);
                }

                // Sign Out User
                await _signInManager.SignOutAsync();

                // Sign In User
                await _signInManager.SignInAsync(getUserDetail, true);

                return RedirectToAction("Index", "Home");
            }

            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {

                var isEmailExist = await _userManager.FindByEmailAsync(registerVM.Email);

                if (isEmailExist != null)
                {
                    ViewBag.Error = "Kullanıcı zaten mevcut!";
                    return View(registerVM);
                }

                var applicationUser = new ApplicationUser
                {
                    Email = registerVM.Email,
                    UserName = registerVM.UserName,
                    FullName = registerVM.FullName,
                    Type = Common.Enums.UserTypeEnum.USER
                };

                var result = await _userManager.CreateAsync(applicationUser, registerVM.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignOutAsync();
                    await _signInManager.SignInAsync(applicationUser, true);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Hata oluştu lütfen daha sonra tekrar deneyiniz!";
                    return View(registerVM);
                }
            }

            return View(registerVM);
        }

    }
}