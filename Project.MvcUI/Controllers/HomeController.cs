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

            // Benzersiz aktivasyon kodu oluþtur
            Guid specId = Guid.NewGuid();

            // Kullanýcý oluþturma
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                ActivationCode = specId,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Kullanýcýyý kaydet
            IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                #region **Rol Atama Ýþlemi**
                // Eðer "Member" rolü yoksa, oluþtur
                var existingRole = await _roleManager.FindByNameAsync("Member");
                if (existingRole == null)
                {
                    AppRole newRole = new() { Name = "Member", CreatedDate = DateTime.Now, Status = DataStatus.Inserted };
                    await _roleManager.CreateAsync(newRole);
                    existingRole = newRole; // Yeni rolü deðiþkene atýyoruz
                }

                // Kullanýcýya "Member" rolünü atamak için AppUserRole nesnesi oluþtur
                AppUserRole appUserRole = new()
                {
                    Id = 0, // EF Core tarafýndan otomatik atanacak
                    UserId = appUser.Id,
                    RoleId = existingRole.Id,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                // **_context ile manuel olarak AppUserRole ekliyoruz**
                await _context.AppUserRoles.AddAsync(appUserRole);
                await _context.SaveChangesAsync();
                #endregion

                // Kullanýcýya aktivasyon e-postasý gönder
                string activationLink = $"<a href='http://localhost:5114/Home/ConfirmEmail?specId={specId}&id={appUser.Id}'>Hesabýnýzý doðrulamak için buraya týklayýn</a>";
                string message = $"<p>Hesabýnýz oluþturulmuþtur.</p><p>Üyeliðinizi tamamlamak için aþaðýdaki baðlantýya týklayýn:</p>{activationLink}";

                MailService.Send(model.Email, body: message);
                TempData["Message"] = "Lütfen hesabýnýzý onaylamak için e-postanýzý kontrol ediniz.";
                return RedirectToAction("RedirectPanel");
            }

            // Kayýt baþarýsýz olursa hata mesajlarýný ekle
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
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
            SignInManager result = await _signInManager.PasswordSignInAsync(appUser, model.Password, true, true);

            if (appUser == null)
            {
                TempData["Message"] = "Kullanýcý bulunamadý.";
                return RedirectToAction("SignIn");
            }

            // Kullanýcýnýn e-posta doðrulamasý yapýlmýþ mý?
            if (!appUser.EmailConfirmed)
            {
                TempData["Message"] = "Hesabýnýzý doðrulamadýnýz. Lütfen e-postanýzý kontrol edin.";
                return RedirectToAction("MailPanel");
            }

            // Kullanýcýyý giriþ yaptýrma iþlemi

            if (result.Succeeded)
            {
                // Kullanýcýnýn rollerini al
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

            TempData["Message"] = "Giriþ baþarýsýz. Kullanýcý adý veya þifre hatalý.";
            return RedirectToAction("SignIn");
        }

        // **MailPanel Sayfasý**
        public IActionResult MailPanel()
        {
            return View();
        }

    }
}
