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

            // Benzersiz aktivasyon kodu olu�tur
            Guid specId = Guid.NewGuid();

            // Kullan�c� olu�turma
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                ActivationCode = specId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Kullan�c�y� kaydet
            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                #region **Rol Atama ��lemi**
                // E�er "Member" rol� yoksa, olu�tur
                var existingRole = await _roleManager.FindByNameAsync("Member");
                if (existingRole == null)
                {
                    AppRole newRole = new() { Name = "Member", CreatedDate = DateTime.Now, Status = DataStatus.Inserted };
                    await _roleManager.CreateAsync(newRole);
                    existingRole = newRole; // Yeni rol� de�i�kene at�yoruz
                }

                // Kullan�c�ya "Member" rol�n� atamak i�in AppUserRole nesnesi olu�tur
                AppUserRole appUserRole = new()
                {
                    Id = 0, // EF Core taraf�ndan otomatik atanacak
                    UserId = appUser.Id,
                    RoleId = existingRole.Id,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                // **_context ile manuel olarak AppUserRole ekliyoruz**
                await _context.AppUserRoles.AddAsync(appUserRole);
                await _context.SaveChangesAsync();
                #endregion

                // Kullan�c�ya aktivasyon e-postas� g�nder
                string activationLink = $"<a href='http://localhost:5114/Home/ConfirmEmail?specId={specId}&id={appUser.Id}'>Hesab�n�z� do�rulamak i�in buraya t�klay�n</a>";
                string message = $"<p>Hesab�n�z olu�turulmu�tur.</p><p>�yeli�inizi tamamlamak i�in a�a��daki ba�lant�ya t�klay�n:</p>{activationLink}";

                MailService.Send(model.Email, body: message);
                TempData["Message"] = "L�tfen hesab�n�z� onaylamak i�in e-postan�z� kontrol ediniz.";
                return RedirectToAction("RedirectPanel");
            }

            // Kay�t ba�ar�s�z olursa hata mesajlar�n� ekle
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
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
            SignInManager result = await _signInManager.PasswordSignInAsync(appUser, model.Password, true, true);

            if (appUser == null)
            {
                TempData["Message"] = "Kullan�c� bulunamad�.";
                return RedirectToAction("SignIn");
            }

            // Kullan�c�n�n e-posta do�rulamas� yap�lm�� m�?
            if (!appUser.EmailConfirmed)
            {
                TempData["Message"] = "Hesab�n�z� do�rulamad�n�z. L�tfen e-postan�z� kontrol edin.";
                return RedirectToAction("MailPanel");
            }

            // Kullan�c�y� giri� yapt�rma i�lemi

            if (result.Succeeded)
            {
                // Kullan�c�n�n rollerini al
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
            else if (result.IsNotAllowed)
            {
                return RedirectToAction("MailPanel");
            }

            TempData["Message"] = "Giri� ba�ar�s�z. Kullan�c� ad� veya �ifre hatal�.";
            return RedirectToAction("SignIn");
        }

        // **MailPanel Sayfas�**
        public IActionResult MailPanel()
        {
            return View();
        }

    }
}
