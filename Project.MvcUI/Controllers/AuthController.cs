using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Tools;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            Guid activationCode = Guid.NewGuid();

            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                ActivationCode = activationCode,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted

            };


            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                #region Rol Atama İşlemi
                IdentityRole<int>? appRole = await _roleManager.FindByNameAsync("Member");
                if (appRole == null) await _roleManager.CreateAsync(new() { Name = "Member" });
                await _userManager.AddToRoleAsync(appUser, "Member");
                #endregion

                string message = $"<p>Hesabınız oluşturulmuştur. Üyeliğinizi tamamlamak için aşağıdaki bağlantıya tıklayınız:</p>" +
                 $"<p><a href='http://localhost:5114/Auth/ConfirmEmail?activationCode={activationCode}&userId={appUser.Id}' " +
                 $"style='color:blue; text-decoration:underline;'>E-posta doğrulama bağlantısı</a></p>";

                MailService.Send(model.Email, body: message, subject: "BilgeHotel Aktivasyon Maili");

                TempData["Message"] = "Lütfen hesabınızı onaylamak için e-postanızı kontrol ediniz.";
                return RedirectToAction("RedirectPanel");
            }

            TempData["Message"] = "Kayıt başarısız";
            return View();
        }

        public IActionResult RedirectPanel()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(Guid activationCode, int userId)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                TempData["Message"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("RedirectPanel");
            }

            if (user.ActivationCode == activationCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["Message"] = "Hesabınız başarıyla onaylandı. Giriş yapabilirsiniz.";
                return RedirectToAction("RedirectPanel");
            }

            TempData["Message"] = "Geçersiz doğrulama kodu.";
            return RedirectToAction("RedirectPanel");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
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

            SignInManager result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (result.Succeeded)
            {
                // **Eğer returnUrl varsa, giriş yaptıktan sonra kullanıcıyı oraya yönlendir**
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                // Kullanıcının rolüne göre yönlendirme yap
                IList<string> roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    // return RedirectToAction("Index", "Dashboard", new { Area = "Admin" }); //TODO: Admin areasi acildiktan sonra aktif edilecek
                    return RedirectToAction("Privacy", "Home");
                }
                else if (roles.Contains("Member"))
                {
                    // return RedirectToAction("Index", "Customer"); //TODO: Customer paneli aktif edilecek
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            else if (result.IsNotAllowed)
            {
                return RedirectToAction("MailPanel");
            }

            TempData["Message"] = "Geçersiz giriş bilgileri.";
            return RedirectToAction("Login");
        }


        public IActionResult MailPanel()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(UserForgotPasswordRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                TempData["Message"] = "Bu e-posta adresi ile kayıtlı bir kullanıcı bulunamadı veya e-posta doğrulanmamış.";
                return RedirectToAction("ForgotPassword");
            }

            // Şifre sıfırlama tokeni oluşturma
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Kullanıcıya şifre sıfırlama linki gönderme
            string resetLink = $"http://localhost:5114/Auth/ResetPassword?token={Uri.EscapeDataString(resetToken)}&email={Uri.EscapeDataString(user.Email)}";

            string message = $"<p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p>" +
                             $"<p><a href='{resetLink}' style='color:blue; text-decoration:underline;'>Şifreyi Sıfırla</a></p>";

            MailService.Send(user.Email, body: message, subject: "Şifre Sıfırlama");


            TempData["Message"] = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.";
            return RedirectToAction("ForgotPassword");
        }

        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                TempData["Message"] = "Geçersiz şifre sıfırlama bağlantısı.";
                return RedirectToAction("ForgotPassword");
            }

            UserResetPasswordRequestModel model = new UserResetPasswordRequestModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserResetPasswordRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "Geçersiz e-posta adresi.";
                return RedirectToAction("ForgotPassword");
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

            if (result.Succeeded)
            {
                // **ModifiedDate ve Status Güncelleniyor**
                user.ModifiedDate = DateTime.Now;
                user.Status = DataStatus.Updated;
                await _userManager.UpdateAsync(user);

                TempData["Message"] = "Şifreniz başarıyla sıfırlandı. Giriş yapabilirsiniz.";
                return RedirectToAction("Login");
            }

            TempData["Message"] = "Şifre sıfırlama başarısız";
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }


    }
}
