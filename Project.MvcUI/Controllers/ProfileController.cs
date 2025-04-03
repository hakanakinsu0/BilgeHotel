using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Models;
using Project.MvcUI.Models.PageVms.AppUsers;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;
using System.Threading.Tasks;

namespace Project.MvcUI.Controllers
{
    [Authorize(Roles = "Member,Admin")]
    public class ProfileController : Controller
    {
        readonly IAppUserManager _appUserManager;
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;

        public ProfileController(IAppUserManager appUserManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        #region Index

        /// <summary>
        /// Kullanıcının profil bilgilerini görüntüler.
        /// Kullanıcı profil bilgileri manager üzerinden alınır, AutoMapper ile UserProfileResponseModel'e map edilir 
        /// ve ek UI bilgileri (başlık, hata/success mesajları) ile sarmalanan PageVM view'e gönderilir.
        /// </summary>

        public async Task<IActionResult> Index()
        {
            // Kullanıcının ID'sini alıp, integer'a dönüştürüyoruz.
            AppUserDto userDto = await _appUserManager.GetUserProfileAsync(Convert.ToInt32(_userManager.GetUserId(User)));
            if (userDto == null)
                return RedirectToAction("Login", "Auth");

            // User DTO'sunu, view'de kullanılacak UserProfileResponseModel'e map ediyoruz.
            UserProfileResponseModel profileResponse = _mapper.Map<UserProfileResponseModel>(userDto);
            // AutoMapper ayarları gereği, enum'ların string'e dönüşümü manuel yapılabilir.
            profileResponse.Gender = userDto.Gender.ToString();
            profileResponse.Nationality = userDto.Nationality;

            // TempData'daki mesajlar PageVM'e aktarılıyor.
            var pageVm = new UserProfilePageVm
            {
                UserProfile = profileResponse,
                SuccessMessage = TempData["SuccessMessage"]?.ToString(),
                ErrorMessage = TempData["ErrorMessage"]?.ToString()
            };

            return View(pageVm);
        }

        #endregion

        #region Edit

        /// <summary>
        /// Kullanıcı profilini güncellemek için GET action.
        /// Kullanıcının mevcut profil bilgilerini manager üzerinden alıp, güncelleme formu için kullanılacak model'e map eder,
        /// ve bu bilgileri ek UI verileriyle saran PageVM ile view'e gönderir.
        /// </summary>
        public async Task<IActionResult> Edit()
        {
            // Kullanıcının profil bilgisini alıyoruz.
            AppUserDto userDto = await _appUserManager.GetUserProfileAsync(Convert.ToInt32(_userManager.GetUserId(User)));
            if (userDto == null)
                return RedirectToAction("Login", "Auth");

            // Kullanıcı profil DTO'sunu, güncelleme için kullanılacak request model'e map ediyoruz.
            UserProfileUpdateRequestModel updateModel = _mapper.Map<UserProfileUpdateRequestModel>(userDto);

            // Güncelleme formu ve ek UI bilgilerini içeren PageVM oluşturuluyor.
            UserProfileEditPageVm pageVm = new()
            {
                UserProfileUpdate = updateModel
            };

            return View(pageVm);
        }

        /// <summary>
        /// Kullanıcı profilini güncellemek için POST action.
        /// Formdan gelen güncelleme verileri doğrulandıktan sonra mevcut profil DTO'suna map edilir,
        /// manager üzerinden güncelleme yapılır ve işlem sonucu TempData ile iletilir.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(UserProfileEditPageVm pageVm)
        {
            // Model validasyonu kontrol ediliyor.
            if (!ModelState.IsValid)
                return View(pageVm);

            // Güncel kullanıcı profil bilgisini alıyoruz.
            AppUserDto userDto = await _appUserManager.GetUserProfileAsync(Convert.ToInt32(_userManager.GetUserId(User)));
            if (userDto == null)
                return RedirectToAction("Login", "Auth");

            // Formdan gelen güncelleme bilgilerini mevcut DTO'ya map ediyoruz.
            _mapper.Map(pageVm.UserProfileUpdate, userDto);

            // Profil güncelleme manager metodunu çağırıyoruz.
            bool updateSuccess = await _appUserManager.UpdateUserProfileAsync(userDto);
            if (updateSuccess)
            {
                // İşlem başarılı ise success mesajı TempData'ya eklenir ve Index'e yönlendirme yapılır.
                TempData["SuccessMessage"] = "Profil başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            // İşlem başarısız olursa hata mesajı TempData'ya eklenir.
            TempData["ErrorMessage"] = "Profil güncellenirken hata oluştu.";
            return View(pageVm);
        }

        #endregion

        #region ChangePassword

        /// <summary>
        /// Kullanıcı şifre değiştirme sayfasını getirir (GET).
        /// Yeni bir ChangePasswordPageVm oluşturulur ve içinde boş bir UserChangePasswordRequestModel örneği atanır.
        /// </summary>
        public IActionResult ChangePassword()
        {
            ChangePasswordPageVm pageVm = new()
            {
                ChangePasswordRequest = new UserChangePasswordRequestModel()
            };

            return View(pageVm);
        }

        /// <summary>
        /// Kullanıcı şifre değiştirme işlemini gerçekleştirir (POST).
        /// Formdan gelen veriler doğrulandıktan sonra, manager üzerinden şifre değiştirme işlemi yapılır.
        /// İşlem sonucu TempData ve/veya PageVM aracılığıyla kullanıcıya bildirilir.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordPageVm pageVm)
        {
            // Model validasyonu kontrol ediliyor.
            if (!ModelState.IsValid)
                return View(pageVm);

            // Kullanıcının ID'sini alıyoruz.
            int userId = Convert.ToInt32(_userManager.GetUserId(User));

            // Şifre değiştirme işlemi, manager metodu üzerinden gerçekleştirilir.
            bool result = await _appUserManager.ChangeUserPasswordAsync(userId, pageVm.ChangePasswordRequest.CurrentPassword, pageVm.ChangePasswordRequest.NewPassword);
            if (result)
            {
                // İşlem başarılı ise, başarı mesajı TempData'ya aktarılır ve Index action'ına yönlendirilir.
                TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirildi.";
                return RedirectToAction("Index");
            }

            // İşlem başarısız ise, hata mesajı PageVM'e set edilerek aynı view render edilir.
            pageVm.ErrorMessage = "Şifre değiştirme sırasında hata oluştu.";
            return View(pageVm);
        }

        #endregion
    }
}
