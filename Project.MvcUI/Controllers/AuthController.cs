using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.AppUsers;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;
using SignInManager = Microsoft.AspNetCore.Identity.SignInResult;


namespace Project.MvcUI.Controllers
{
    /// <summary>
    /// Kullanıcı kimlik doğrulama işlemlerini (kayıt, giriş, şifre sıfırlama, vs.) yöneten controller. 
    /// </summary>
    public class AuthController : Controller
    {
        // Sabit tanımlamalar
        const string MemberRole = "Member";             // Rol ismi sabiti 
        const string BaseUrl = "http://localhost:5114"; // Aktivasyon ve reset linkleri için temel URL sabiti

        readonly UserManager<AppUser> _userManager;             // Kullanıcı yönetim servisi 
        readonly SignInManager<AppUser> _signInManager;         // Giriş yönetim servisi 
        readonly RoleManager<IdentityRole<int>> _roleManager;   // Rol yönetim servisi 
        readonly IMapper _mapper;                               // AutoMapper servisi 
        readonly IAppUserManager _appUserManager;               // Uygulama kullanıcı yönetim servisi 

        /// <summary>
        /// Controller'ın contructer'i. Gerekli servisler dependency injection ile alınır. 
        /// </summary>
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole<int>> roleManager, IMapper mapper, IAppUserManager appUserManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _appUserManager = appUserManager;
        }

        #region RegisterAction

        /// <summary>
        /// Kayıt sayfasını görüntüler.
        /// </summary>
        public IActionResult Register()
        {
            RegisterPageViewModel viewModel = new RegisterPageViewModel(); // Page VM oluştur
            return View(viewModel); // View'a gönder
        }

        /// <summary>
        /// Kullanıcı kayıt işlemini gerçekleştirir; model validasyonu, email kontrolü, kullanıcı oluşturma, rol atama, aktivasyon maili gönderimi ve yönlendirme işlemleri yapılır.
        /// </summary>
        /// <param name="viewModel">Kayıt sayfasına özgü view model</param>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterPageViewModel viewModel)
        {
            UserRegisterRequestModel model = viewModel.RegisterRequest;     // Pure model, page VM içerisindeki RegisterRequest'ten elde ediliyor.
            UserRegisterResponseModel response = new(); // Kayıt response modeli oluştur

            // Model validasyonunu kontrol et
            if (!ModelState.IsValid)
                return ProcessResponse(response, viewModel, false, "Lütfen eksik veya hatalı alanları kontrol edin.");

            // Kullanıcı kontrolü: Hem e-posta hem de kullanıcı adı kontrolü
            if (await _appUserManager.FindUserByEmailAsync(model.Email) != null || await _userManager.FindByNameAsync(model.UserName) != null)
                return ProcessResponse(response, viewModel, false, "Bu e-posta adresi veya kullanıcı adı zaten kullanımda.");

            // Aktivasyon kodu üretimi
            Guid activationCode = _appUserManager.GenerateActivationCode();

            // Yeni kullanıcı nesnesinin oluşturulması
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email,
                ActivationCode = activationCode,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Kullanıcı oluşturma
            IdentityResult result = await _appUserManager.CreateUserAsync(appUser, model.Password);

            if (!result.Succeeded)
                return ProcessResponse(response, viewModel, false, "Kayıt başarısız.");

            // Rol ataması (örneğin "Member" rolü)
            IdentityResult roleResult = await _appUserManager.AssignRoleAsync(appUser, MemberRole);
            if (!roleResult.Succeeded)
                return ProcessResponse(response, viewModel, false, "Rol ataması başarısız.");

            // Aktivasyon mailinin gönderilmesi
            await _appUserManager.SendActivationEmailAsync(appUser, activationCode);

            return ProcessResponse(response, viewModel, true, "Lütfen hesabınızı onaylamak için e-postanızı kontrol ediniz.", "RedirectPanel");
        }

        /// <summary>
        /// RedirectPanel paneli görünümünü döndürür. 
        /// </summary>
        public IActionResult RedirectPanel()
        {
            return View(); // RedirectPanel view'ını döndür 
        }

        #endregion

        #region ConfirmEmailAction

        /// <summary>
        /// E-posta doğrulama işlemini gerçekleştirir; aktivasyon kodu kontrolü ve email onaylama yapılır. 
        /// </summary>
        /// <param name="activationCode">Aktivasyon kodu</param>
        /// <param name="userId">Kullanıcı ID'si</param>
        public async Task<IActionResult> ConfirmEmail(Guid activationCode, int userId)
        {
            UserConfirmEmailResponseModel response = new();

            // Manager'daki ConfirmEmailAsync metodu çağrılıyor.
            IdentityResult result = await _appUserManager.ConfirmEmailAsync(userId, activationCode);

            if (result.Succeeded)
            {
                SetResponseMessage(response, true, "Hesabınız başarıyla onaylandı. Giriş yapabilirsiniz.");
                return RedirectToAction("Login");
            }

            SetResponseMessage(response, false, "Hesabınız onaylanmadı. Bilgilerinizi kontrol ediniz.");
            return RedirectToAction("RedirectPanel");
        }

        #endregion

        #region LoginAction

        /// <summary>
        /// Giriş sayfasını görüntüler. 
        /// </summary>
        public IActionResult Login()
        {
            LoginPageViewModel viewModel = new(); // Login Page VM oluştur

            // TempData'da mesaj varsa, bunu view model'in ErrorMessage alanına aktar
            if (TempData["Message"] != null)
            {
                viewModel.ErrorMessage = TempData["Message"]!.ToString(); // '!' operatörü, TempData["Message"] değerinin null olmadığını garanti altına almak için kullanılır. Böylece ToString() metodu çağrıldığında null referans hatası alınmaz.
            }
            return View(viewModel); // View'a gönder
        }

        /// <summary>
        /// Kullanıcı giriş işlemini gerçekleştirir; model validasyonu, kullanıcı kontrolü, email onayı, kilitlenme kontrolü ve rol bazlı yönlendirme yapılır.
        /// </summary>
        /// <param name="viewModel">Giriş sayfasına özgü view model</param>
        [HttpPost]
        public async Task<IActionResult> Login(LoginPageViewModel viewModel)
        {
            UserLoginRequestModel model = viewModel.LoginRequest; // Pure model, LoginPageViewModel içerisindeki LoginRequest'ten elde ediliyor.
            UserLoginResponseModel response = new(); // Giriş response modeli oluştur

            // Model doğrulamasını kontrol et
            if (!ModelState.IsValid)
                return ProcessResponse(response, viewModel, false, "Lütfen eksik veya hatalı alanları kontrol edin.");

            AppUser? user = await _userManager.FindByEmailAsync(model.Email); // Email ile kullanıcıyı bul 

            // Kullanıcı bulunamazsa
            if (user == null)
                return ProcessResponse(response, viewModel, false, "Geçersiz e-posta veya şifre.");

            // Email onayı yapılmamışsa
            if (!user.EmailConfirmed)
                return ProcessResponse(response, viewModel, false, "Lütfen e-postanızı onaylayın.", "MailPanel");

            // Hesap pasifse giriş reddedilir
            if (user.Status == DataStatus.Deleted)
                return ProcessResponse(response, viewModel, false, "Hesabınız pasif durumdadır. Lütfen yönetici ile iletişime geçin.");


            SignInManager result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true); // Giriş işlemini dene 

            // Hesap kilitlendiyse
            if (result.IsLockedOut)
                return ProcessResponse(response, viewModel, false, "Çok fazla hatalı giriş yaptınız. Lütfen 3 dakika sonra tekrar deneyin.");

            if (result.Succeeded) // Giriş başarılı ise
            {
                // Eğer returnUrl varsa, ona yönlendir
                if (!string.IsNullOrEmpty(model.ReturnUrl))
                    return LocalRedirect(model.ReturnUrl); // LocalRedirect, verilen URL'nin yerel bir URL olduğunu kontrol eder. Eğer URL yerel değilse, yönlendirme yapılmaz ve güvenlik açısından hata fırlatır. Bu, açık yönlendirme saldırılarına karşı ekstra bir koruma sağlar.

                // Kullanıcı profilinden IdentityNumber kontrolü
                AppUserDto userProfile = await _appUserManager.GetUserProfileAsync(user.Id); // Profil bilgilerini al 

                if (string.IsNullOrEmpty(userProfile.IdentityNumber)) // Kimlik numarası boş ise
                    return RedirectToAction("Edit", "Profile"); // Profil düzenleme sayfasına yönlendir 

                // Kullanıcının rollerine göre yönlendirme
                IList<string> roles = await _userManager.GetRolesAsync(user); // Rollerini al 

                if (roles.Contains("Admin")) // Admin rolüne sahipse
                    return RedirectToAction("Index", "Dashboard", new { Area = "Admin" }); // Admin paneline yönlendir 

                else if (roles.Contains(MemberRole)) // Member rolüne sahipse
                    return RedirectToAction("Index", "Home"); // Üye (şimdilik Home) paneline yönlendir 

                return RedirectToAction("Index", "Home"); // Diğer durumlarda varsayılan yönlendirme 
            }

            return ProcessResponse(response, viewModel, false, "Geçersiz giriş bilgileri.", "Login");
        }

        /// <summary>
        /// Mail onay paneli görünümünü döndürür. 
        /// </summary>
        public IActionResult MailPanel()
        {
            return View(); // MailPanel'i döndür 
        }


        #endregion

        #region ForgotPasswordAction

        /// <summary>
        /// Şifre sıfırlama sayfasını görüntüler.
        /// </summary>
        public IActionResult ForgotPassword()
        {
            ForgotPasswordPageViewModel viewModel = new ForgotPasswordPageViewModel(); // Page VM oluştur
            return View(viewModel); // View'a gönder
        }

        /// <summary>
        /// Şifre sıfırlama işlemini gerçekleştirir; model validasyonu, kullanıcı kontrolü, token oluşturma, reset linki oluşturma ve mail gönderimi yapılır. 
        /// </summary>
        /// <param name="model">Şifre sıfırlama isteği model verileri</param>
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordPageViewModel viewModel)
        {
            UserForgotPasswordRequestModel model = viewModel.ForgotPasswordRequest; // Pure model, Page VM içerisindeki ForgotPasswordRequest'ten elde ediliyor.
            UserForgotPasswordResponseModel response = new(); // Response model oluştur

            // Hata durumunda ProcessResponse çağrısı ile viewModel güncellenip view'e gönderilir.
            if (!ModelState.IsValid)
                return ProcessResponse(response, viewModel, false, "Lütfen eksik veya hatalı alanları kontrol edin.");

            // Manager üzerinden şifre sıfırlama maili gönderme işlemini gerçekleştiriyoruz.
            IdentityResult result = await _appUserManager.SendPasswordResetEmailAsync(model.Email);

            // Başarılı durumda RedirectPanel'e yönlendirme yapılır.
            if (result.Succeeded)
                return ProcessResponse(response, viewModel, true, "Şifre sıfırlama bağlantısı e-posta adresinize gönderildi.", "RedirectPanel");

            // İşlem başarısız ise ProcessResponse ile viewModel güncellenir ve view'e gönderilir.
            return ProcessResponse(response, viewModel, false, "Şifre sıfırlama işlemi başarısız.");
        }

        #endregion

        #region ResetPasswordAction

        /// <summary>
        /// Şifre sıfırlama sayfasını, token ve email bilgisiyle birlikte görüntüler.
        /// </summary>
        /// <param name="token">Şifre sıfırlama tokeni</param>
        /// <param name="email">Kullanıcının email adresi</param>
        public IActionResult ResetPassword(string token, string email)
        {
            ResetPasswordPageViewModel viewModel = new(); // Page VM oluştur
            viewModel.ResetPasswordRequest.Token = token; // Token ata
            viewModel.ResetPasswordRequest.Email = email; // Email ata

            // Eğer token veya email boş ise, hata mesajı ayarlanarak view model gönderilir.
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                // Burada viewModel'i hem response hem de viewModel olarak gönderiyoruz.
                return ProcessResponse(viewModel, viewModel, false, "Geçersiz şifre sıfırlama bağlantısı.");
            }

            return View(viewModel);
        }

        /// <summary>
        /// Şifre sıfırlama işlemini gerçekleştirir; model validasyonu, token doğrulaması, şifre güncellemesi ve kullanıcı güncelleme işlemleri yapılır.
        /// </summary>
        /// <param name="viewModel">Yeni şifre ve reset token bilgilerini içeren sayfa view modeli</param>
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordPageViewModel viewModel)
        {
            // Pure model, Page VM içerisindeki ResetPasswordRequest'ten elde ediliyor.
            UserResetPasswordRequestModel model = viewModel.ResetPasswordRequest;
            UserResetPasswordResponseModel response = new(); // Response model oluştur

            // Model validasyonunu kontrol et
            if (!ModelState.IsValid)
                return ProcessResponse(response, viewModel, false, "Lütfen eksik veya hatalı alanları kontrol edin.");

            AppUser? user = await _userManager.FindByEmailAsync(model.Email); // Email ile kullanıcıyı bul 

            // Kullanıcı bulunamazsa
            if (user == null)
                return ProcessResponse(response, viewModel, false, "Geçersiz e-posta adresi.", "ForgotPassword");

            IdentityResult result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword); // Şifre sıfırlama işlemini gerçekleştir 

            // İşlem başarılı ise
            if (result.Succeeded)
            {
                return ProcessResponse(response, viewModel, true, "Şifreniz başarıyla sıfırlandı. Giriş yapabilirsiniz.", "Login");
            }
            return ProcessResponse(response, viewModel, false, "Şifre sıfırlama işlemi başarısız.");
        }
        #endregion

        #region LogoutAction

        /// <summary>
        /// Kullanıcının çıkış işlemini gerçekleştirir ve ana sayfaya yönlendirir. 
        /// </summary>
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();        // Kullanıcıyı sistemden çıkışı yapar
            return RedirectToAction("Index", "Home");   // Ana sayfaya yönlendir 
        }
        #endregion

        #region ControllerPrivateMethods

        /// <summary>
        /// Response nesnesine, verilen başarı durumuna ve mesaja göre
        /// Success ve Message alanlarını atar; ayrıca TempData'ya da aynı mesajı yazar.
        /// </summary>
        /// <param name="response">Hata/success bilgisini tutacak dinamik response nesnesi.</param>
        /// <param name="success">İşlemin başarılı olup olmadığını belirtir.</param>
        /// <param name="message">Atanacak hata/success mesajı.</param>
        private void SetResponseMessage(dynamic response, bool success, string message)
        {
            response.Success = success; // Başarı durumunu ata
            response.Message = message; // Mesajı ata
            TempData["Message"] = message; // TempData'ya mesajı ata
        }

        /// <summary>
        /// Verilen view model üzerinde response mesajını ayarlayarak; 
        /// eğer yönlendirme parametresi sağlanmışsa belirtilen aksiyona yönlendirir,
        /// aksi halde view model ile view'i render eder.
        /// </summary>
        /// <typeparam name="T">Kullanılacak view model tipi (ErrorMessage alanı olmalı)</typeparam>
        /// <param name="response">Response nesnesi (dinamik, Success ve Message alanlarını içerir).</param>
        /// <param name="viewModel">Geri gönderilecek view model.</param>
        /// <param name="success">İşlemin başarılı olup olmadığını belirtir.</param>
        /// <param name="message">Görüntülenecek hata/success mesajı.</param>
        /// <param name="redirectAction">Yönlendirme yapılacak action adı; boş ise view render edilir.</param>
        /// <returns>ActionResult: Yönlendirme veya view döndürür.</returns>
        private IActionResult ProcessResponse<T>(dynamic response, T viewModel, bool success, string message, string? redirectAction = null) where T : class
        {
            SetResponseMessage(response, success, message); // Response mesajını ayarla
            dynamic vm = viewModel; // viewModel'in ErrorMessage property'sine erişmek için dynamic'e cast et
            vm.ErrorMessage = response.Message; // Hata/success mesajını viewModel'e aktar

            // Eğer redirectAction sağlanmışsa ilgili aksiyona yönlendir, aksi halde view model ile view'e gönder
            if (string.IsNullOrEmpty(redirectAction))
                return View(viewModel);
            else
                return RedirectToAction(redirectAction);
        }

        #endregion
    }
}
