using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Tools;
using Project.Entities.Models;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SignInManager = Microsoft.AspNetCore.Identity.SignInResult;

namespace Project.MvcUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        // **Kayıt Ol Sayfası**
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            Guid activationCode = Guid.NewGuid();
            var appUser = _mapper.Map<AppUser>(model);
            appUser.ActivationCode = activationCode;
            appUser.CreatedDate = DateTime.Now;

            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                #region Rol Kontrol İşlemleri
                IdentityRole<int> appRole = await _roleManager.FindByNameAsync("Member");
                if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Member" });
                await _userManager.AddToRoleAsync(appUser, "Member");
                #endregion

                string message = $"Hesabınız oluşturulmuştur. Üyeliğinizi tamamlamak için aşağıdaki bağlantıya tıklayınız:\n\n" +
                                 $"http://localhost:5000/Auth/ConfirmEmail?activationCode={activationCode}&userId={appUser.Id}";

                MailService.Send(model.Email, body: message);
                TempData["Message"] = "Lütfen hesabınızı onaylamak için e-postanızı kontrol ediniz.";
                return RedirectToAction("RedirectPanel");
            }

            TempData["Message"] = "Kayıt başarısız: " + string.Join(" | ", result.Errors.Select(e => e.Description));
            return View();
        }

        public IActionResult RedirectPanel()
        {
            return View();
        }

        // **E-posta Doğrulama**
        public async Task<IActionResult> ConfirmEmail(Guid activationCode, int userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                TempData["Message"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("RedirectPanel");
            }
            else if (user.ActivationCode == activationCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["Message"] = "Hesabınız başarıyla onaylandı.";
                return RedirectToAction("Login");
            }

            return RedirectToAction("Register");
        }

        // **Giriş Yap Sayfası**
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            AppUser user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "Geçersiz e-posta veya şifre.";
                return RedirectToAction("Login");
            }

            if (!user.EmailConfirmed)
            {
                TempData["Message"] = "Lütfen e-postanızı onaylayın.";
                return RedirectToAction("MailPanel");
            }

            SignInManager result = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);

            if (result.Succeeded)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                }
                else if (roles.Contains("Member"))
                {
                    return RedirectToAction("Index", "Customer");
                }
                return RedirectToAction("Index", "Home");
            }
            else if (result.IsNotAllowed)
            {
                return RedirectToAction("MailPanel");
            }

            TempData["Message"] = "Kullanıcı bulunamadı.";
            return RedirectToAction("Login");
        }

        public IActionResult MailPanel()
        {
            return View();
        }

        // **Çıkış Yap**
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
