using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;
using Project.Common.Tools;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;
using SignInManager = Microsoft.AspNetCore.Identity.SignInResult;


namespace Project.MvcUI.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;
        private readonly IAppUserManager _appUserManager;


        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager, IMapper mapper, IAppUserManager appUserManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _appUserManager = appUserManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Lütfen eksik veya hatalı alanları kontrol edin.";
                return View(model);
            }

            AppUser? existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                TempData["Message"] = "Bu e-posta adresi zaten kullanımda.";
                return View(model);
            }

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
            UserLoginResponseModel response = new();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Lütfen eksik veya hatalı alanları kontrol edin.";

                // ModelState içindeki tüm hata mesajlarını al ve TempData içinde göster
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                TempData["Message"] = string.Join(" ", errors);

                return RedirectToAction("Login");
            }


            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                response.Success = false;
                response.Message = "Geçersiz e-posta veya şifre.";
                TempData["Message"] = response.Message;
                return RedirectToAction("Login");
            }

            if (!user.EmailConfirmed)
            {
                response.Success = false;
                response.Message = "Lütfen e-postanızı onaylayın.";
                TempData["Message"] = response.Message;
                return RedirectToAction("MailPanel");
            }

            SignInManager result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (result.IsLockedOut)
            {
                response.Success = false;
                response.Message = "Çok fazla hatalı giriş yaptınız. Lütfen 3 dakika sonra tekrar deneyin.";
                TempData["Message"] = response.Message;
                return RedirectToAction("Login");
            }

            if (result.Succeeded)
            {
                // **Eğer returnUrl varsa, giriş yaptıktan sonra kullanıcıyı oraya yönlendir**
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                // **IdentityNumber kontrolü ekleyelim**
                var userProfile = await _appUserManager.GetUserProfileAsync(user.Id);
                if (string.IsNullOrEmpty(userProfile.IdentityNumber)) // Eğer kimlik numarası girilmemişse
                {
                    return RedirectToAction("Edit", "Profile"); // Profil düzenleme sayfasına yönlendir
                }

                // Kullanıcının rolüne göre yönlendirme yap
                IList<string> roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
                //return RedirectToAction("Privacy", "Home");
                }
                else if (roles.Contains("Member"))
                {
                    // return RedirectToAction("Index", "Customer"); //TODO: Customer paneli aktif edilecek
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }

            response.Success = false;
            response.Message = "Geçersiz giriş bilgileri.";
            TempData["Message"] = response.Message;
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
            UserForgotPasswordResponseModel response = new();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Lütfen eksik veya hatalı alanları kontrol edin.";
                TempData["Message"] = response.Message;
                return View(model);
            }

            AppUser? user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                response.Success = true;
                response.Message = "Eğer bu e-posta adresi sistemde kayıtlı ise şifre sıfırlama bağlantısı gönderilmiştir.";
                TempData["Message"] = response.Message;
                return RedirectToAction("ForgotPassword");
            }

            // Şifre sıfırlama tokeni oluşturma
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Kullanıcıya şifre sıfırlama linki gönderme
            string resetLink = $"http://localhost:5114/Auth/ResetPassword?token={Uri.EscapeDataString(resetToken)}&email={Uri.EscapeDataString(user.Email)}";

            string message = $"<p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p>" +
                             $"<p><a href='{resetLink}' style='color:blue; text-decoration:underline;'>Şifreyi Sıfırla</a></p>";

            MailService.Send(user.Email, body: message, subject: "BilgeHotel Şifre Sıfırlama");

            response.Success = true;
            response.Message = "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.";
            TempData["Message"] = response.Message;
            return RedirectToAction("ForgotPassword");
        }

        public IActionResult ResetPassword(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Geçersiz şifre sıfırlama bağlantısı.");
                return View();
            }

            UserResetPasswordRequestModel model = new UserResetPasswordRequestModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserResetPasswordRequestModel model)
        {
            UserResetPasswordResponseModel response = new();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Lütfen eksik veya hatalı alanları kontrol edin.";
                TempData["Message"] = response.Message;
                return View(model);
            }

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

            response.Success = false;
            response.Message = string.Join(" ", result.Errors.Select(e => e.Description));
            TempData["Message"] = response.Message;
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
