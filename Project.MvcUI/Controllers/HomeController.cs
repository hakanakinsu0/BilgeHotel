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
        //            body: "Bu bir test e-postas�d�r.",
        //            subject: "Test Mail",
        //            sender: "testemail3172@gmail.com"
        //        );

        //        return Content("E-posta ba�ar�yla g�nderildi!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Content($"E-posta g�nderme s�ras�nda hata olu�tu: {ex.Message}");
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

            // **Mevcut e-posta kontrol�**
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi ile zaten bir hesap olu�turulmu�.");
                return View(model);
            }

            // **Benzersiz aktivasyon kodu olu�tur**
            Guid specId = Guid.NewGuid();

            // **Yeni Kullan�c� Olu�turma**
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                ActivationCode = specId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // **�ifreyi Identity ile kontrol et ve hata mesajlar�n� al**
            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                await AssignUserRole(appUser, "Member", _context);

                // **Aktivasyon Maili G�nder**
                string activationLink = $"<a href='http://localhost:5114/Home/ConfirmEmail?specId={specId}&id={appUser.Id}'>Hesab�n�z� do�rulamak i�in buraya t�klay�n</a>";
                string message = $"<p>Hesab�n�z olu�turulmu�tur.</p><p>�yeli�inizi tamamlamak i�in a�a��daki ba�lant�ya t�klay�n:</p>{activationLink}";

                MailService.Send(model.Email, body: message);
                TempData["Message"] = "L�tfen hesab�n�z� onaylamak i�in e-postan�z� kontrol ediniz.";
                return RedirectToAction("RedirectPanel");
            }

            // **Hata mesajlar�n� UI taraf�na ekleyelim**
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



        // Kullan�c�ya y�nlendirme mesaj� g�stermek i�in basit bir sayfa
        public IActionResult RedirectPanel()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(Guid specId, int id)
        {
            // Kullan�c�y� ID'ye g�re bul
            AppUser user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                TempData["Message"] = "Kullan�c� bulunamad�.";
                return RedirectToAction("RedirectPanel");
            }

            // E�er aktivasyon kodu e�le�iyorsa, e-posta do�rulamas�n� ger�ekle�tir
            if (user.ActivationCode == specId)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);

                TempData["Message"] = "Hesab�n�z ba�ar�yla onayland�. Art�k giri� yapabilirsiniz.";
                return RedirectToAction("SignIn");
            }

            TempData["Message"] = "Ge�ersiz aktivasyon kodu.";
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

            // Kullan�c�y� UserName ile bul
            AppUser appUser = await _userManager.FindByNameAsync(model.UserName);

            if (appUser == null)
            {
                ModelState.AddModelError("", "B�yle bir kullan�c� bulunamad�.");
                return View(model);
            }

            // Kullan�c�n�n e-posta do�rulamas� yap�lm�� m�?
            if (!appUser.EmailConfirmed)
            {
                ModelState.AddModelError("", "Hesab�n�z do�rulanmam��! L�tfen e-postan�z� kontrol edin.");
                return View(model);
            }

            // Kullan�c� giri� yapmay� deniyor, ancak ba�ar�s�z deneme s�n�r� var.
            var result = await _signInManager.PasswordSignInAsync(appUser, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                // Kullan�c�n�n rollerini al ve y�nlendir
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
                ModelState.AddModelError("", "Hesab�n�z �ok fazla hatal� giri� nedeniyle ge�ici olarak kilitlendi. L�tfen 10 dakika sonra tekrar deneyin.");
                return View(model);
            }

            ModelState.AddModelError("", "Giri� ba�ar�s�z! Kullan�c� ad� veya �ifre yanl��.");
            return View(model);
        }


        // **MailPanel Sayfas�**
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
                TempData["Message"] = "E�er bu e-posta sistemimizde kay�tl�ysa, �ifre s�f�rlama ba�lant�s� g�nderilmi�tir.";
                return RedirectToAction("ForgotPassword");
            }

            // �ifre s�f�rlama token'� olu�tur
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Kullan�c�ya e-posta ile link g�nder
            string resetLink = Url.Action("ResetPassword", "Home", new { email = user.Email, token = token }, Request.Scheme);
            string message = $"�ifrenizi s�f�rlamak i�in <a href='{resetLink}'>buraya t�klay�n</a>.";

            MailService.Send(user.Email, body: message);
            TempData["Message"] = "�ifre s�f�rlama ba�lant�s� e-posta adresinize g�nderildi.";

            return RedirectToAction("ForgotPassword");
        }


        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                TempData["Message"] = "Ge�ersiz �ifre s�f�rlama ba�lant�s�.";
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

            // Kullan�c�y� e-posta adresiyle bul
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                TempData["Message"] = "Ge�ersiz �ifre s�f�rlama iste�i.";
                return RedirectToAction("SignIn");
            }

            // Kullan�c�dan gelen token de�erini decode edelim (Baz� sistemlerde token URL encoding ile gelebilir)
            var decodedToken = model.Token.Replace(" ", "+");

            // �ifre s�f�rlama i�lemi
            var resetResult = await _userManager.ResetPasswordAsync(user, decodedToken, model.NewPassword);

            if (resetResult.Succeeded)
            {
                // **Status ve ModifiedDate G�ncelleniyor**
                user.ModifiedDate = DateTime.Now;
                user.Status = DataStatus.Updated; // E�er `DataStatus` enum'�nda Updated varsa

                await _userManager.UpdateAsync(user); // Kullan�c� g�ncelleniyor
                await _userManager.UpdateSecurityStampAsync(user); // G�venlik damgas� g�ncelleniyor

                TempData["Message"] = "�ifreniz ba�ar�yla g�ncellendi. Yeni �ifrenizle giri� yapabilirsiniz.";
                return RedirectToAction("SignIn");
            }

            // E�er hata olursa kullan�c�ya g�ster
            foreach (var error in resetResult.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Message"] = "Ba�ar�yla ��k�� yapt�n�z.";
            return RedirectToAction("SignIn");
        }


    }
}
