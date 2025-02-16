using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Common.Tools;
using Project.Dal.ContextClasses;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models;
using Project.MvcUI.Models.PureVms.AppUsers;
using System.Diagnostics;
using SignInManager = Microsoft.AspNetCore.Identity.SignInResult;


namespace Project.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Member")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region MailGonderimTesti
        //public IActionResult SendTestMail()
        //{
        //    try
        //    {
        //        MailService.Send(
        //            receiver: "hakanakinsu.37@gmail.com",
        //            body: "Bu bir test e-postasýdýr.",
        //            subject: "Test Mail",
        //            sender: "testemail3172@gmail.com"
        //        );

        //        return Content("E-posta baþarýyla gönderildi!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content($"E-posta gönderme sýrasýnda hata oluþtu: {ex.Message}");
        //    }
        //} 
        #endregion

        // **GET: Register**
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model, [FromServices] MyContext _context)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // **Mevcut e-posta kontrolü**
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi ile zaten bir hesap oluþturulmuþ.");
                return View(model);
            }

            // **Benzersiz aktivasyon kodu oluþtur**
            Guid specId = Guid.NewGuid();

            // **Yeni Kullanýcý Oluþturma**
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                ActivationCode = specId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // **Þifreyi Identity ile kontrol et ve hata mesajlarýný al**
            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                await AssignUserRole(appUser, "Member", _context);

                // **Aktivasyon Maili Gönder**
                string activationLink = $"<a href='http://localhost:5114/Home/ConfirmEmail?specId={specId}&id={appUser.Id}'>Hesabýnýzý doðrulamak için buraya týklayýn</a>";
                string message = $"<p>Hesabýnýz oluþturulmuþtur.</p><p>Üyeliðinizi tamamlamak için aþaðýdaki baðlantýya týklayýn:</p>{activationLink}";

                MailService.Send(model.Email, body: message);
                TempData["Message"] = "Lütfen hesabýnýzý onaylamak için e-postanýzý kontrol ediniz.";
                return RedirectToAction("RedirectPanel");
            }

            // **Hata mesajlarýný UI tarafýna ekleyelim**
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        private async Task AssignUserRole(AppUser appUser, string roleName, MyContext _context)
        {
            AppRole existingRole = await _roleManager.FindByNameAsync(roleName);
            if (existingRole == null)
            {
                AppRole newRole = new() { Name = roleName, CreatedDate = DateTime.Now, Status = DataStatus.Inserted };
                await _roleManager.CreateAsync(newRole);
                existingRole = newRole;
            }

            AppUserRole appUserRole = new()
            {
                UserId = appUser.Id,
                RoleId = existingRole.Id,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            await _context.AppUserRoles.AddAsync(appUserRole);
            await _context.SaveChangesAsync();
        }



        // Kullanýcýya yönlendirme mesajý göstermek için basit bir sayfa
        public IActionResult RedirectPanel()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(Guid specId, int id)
        {
            // Kullanýcýyý ID'ye göre bul
            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                TempData["Message"] = "Kullanýcý bulunamadý.";
                return RedirectToAction("RedirectPanel");
            }

            // Eðer aktivasyon kodu eþleþiyorsa, e-posta doðrulamasýný gerçekleþtir
            if (user.ActivationCode == specId)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                TempData["Message"] = "Hesabýnýz baþarýyla onaylandý. Artýk giriþ yapabilirsiniz.";
                return RedirectToAction("SignIn");
            }

            TempData["Message"] = "Geçersiz aktivasyon kodu.";
            return RedirectToAction("Register");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanýcýyý UserName ile bul
            AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError("", "Böyle bir kullanýcý bulunamadý.");
                return View(model);
            }

            // Kullanýcýnýn e-posta doðrulamasý yapýlmýþ mý?
            if (!appUser.EmailConfirmed)
            {
                ModelState.AddModelError("", "Hesabýnýz doðrulanmamýþ! Lütfen e-postanýzý kontrol edin.");
                return View(model);
            }

            // Kullanýcý giriþ yapmayý deniyor, ancak baþarýsýz deneme sýnýrý var.
            var result = await _signInManager.PasswordSignInAsync(appUser, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                // Kullanýcýnýn rollerini al ve yönlendir
                IList<string> roles = await _userManager.GetRolesAsync(appUser);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else if (roles.Contains("Member"))
                {
                    return RedirectToAction("Privacy", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
            else if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabýnýz çok fazla hatalý giriþ nedeniyle geçici olarak kilitlendi. Lütfen 10 dakika sonra tekrar deneyin.");
                return View(model);
            }

            ModelState.AddModelError("", "Giriþ baþarýsýz! Kullanýcý adý veya þifre yanlýþ.");
            return View(model);
        }


        // **MailPanel Sayfasý**
        public IActionResult MailPanel()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                TempData["Message"] = "Eðer bu e-posta sistemimizde kayýtlýysa, þifre sýfýrlama baðlantýsý gönderilmiþtir.";
                return RedirectToAction("ForgotPassword");
            }

            // Þifre sýfýrlama token'ý oluþtur
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Kullanýcýya e-posta ile link gönder
            string resetLink = Url.Action("ResetPassword", "Home", new { email = user.Email, token = token }, Request.Scheme);
            string message = $"Þifrenizi sýfýrlamak için <a href='{resetLink}'>buraya týklayýn</a>.";

            MailService.Send(user.Email, body: message);
            TempData["Message"] = "Þifre sýfýrlama baðlantýsý e-posta adresinize gönderildi.";

            return RedirectToAction("ForgotPassword");
        }


        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                TempData["Message"] = "Geçersiz þifre sýfýrlama baðlantýsý.";
                return RedirectToAction("SignIn");
            }

            var model = new ResetPasswordRequestModel
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanýcýyý e-posta adresiyle bul
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "Geçersiz þifre sýfýrlama isteði.";
                return RedirectToAction("SignIn");
            }

            // Kullanýcýdan gelen token deðerini decode edelim (Bazý sistemlerde token URL encoding ile gelebilir)
            var decodedToken = model.Token.Replace(" ", "+");

            // Þifre sýfýrlama iþlemi
            var resetResult = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);

            if (resetResult.Succeeded)
            {
                // **Status ve ModifiedDate Güncelleniyor**
                user.ModifiedDate = DateTime.Now;
                user.Status = DataStatus.Updated; // Eðer `DataStatus` enum'ýnda Updated varsa

                await _userManager.UpdateAsync(user); // Kullanýcý güncelleniyor
                await _userManager.UpdateSecurityStampAsync(user); // Güvenlik damgasý güncelleniyor

                TempData["Message"] = "Þifreniz baþarýyla güncellendi. Yeni þifrenizle giriþ yapabilirsiniz.";
                return RedirectToAction("SignIn");
            }

            // Eðer hata olursa kullanýcýya göster
            foreach (var error in resetResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Message"] = "Baþarýyla çýkýþ yaptýnýz.";
            return RedirectToAction("SignIn");
        }


    }
}
