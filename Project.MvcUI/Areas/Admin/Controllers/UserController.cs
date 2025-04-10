using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.MvcUI.Areas.Admin.Models;
using Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers;
using Project.MvcUI.Areas.Admin.Models.ResponseModels.AppUsers;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    /// <summary>
    /// Admin panelinde kullanıcı (AppUser) yönetimini sağlar.
    /// Kullanıcı oluşturma, düzenleme, silme, şifre değiştirme ve rol atama işlemlerini içerir.
    /// Sadece Admin rolüne sahip kullanıcılar erişebilir.
    /// </summary>

    [Area("Admin")]
    [Authorize(Roles = "Admin")] 
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager; 
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IAppUserProfileManager appUserProfileManager, IAppUserManager appUserManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager; 
            _appUserProfileManager = appUserProfileManager;
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        #region UserIndexAction

        /// <summary>
        /// Kullanıcı listesini filtreleme kriterlerine göre getirir.
        /// Arama, rol ve durum parametrelerine göre kullanıcılar BLL'den alınır ve UI modeline dönüştürülür.
        /// </summary>
        /// <param name="request">Arama metni, kullanıcı rolü ve durum bilgilerini içeren filtreleme modeli</param>
        /// <returns>Filtrelenmiş kullanıcıların listelendiği view</returns>
        public async Task<IActionResult> Index(UserIndexRequestModel request)
        {
            // BLL'den kullanıcılar filtreleme kriterlerine göre detaylı olarak alınır
            List<AppUserDto> userDtos = await _appUserManager.GetUsersWithDetailsAsync(
                request.Search,   // Ad, soyad veya e-posta gibi metinlerle arama
                request.Role,     // Kullanıcı rolüne göre filtreleme
                request.Status    // Kullanıcının aktif/pasif durumuna göre filtreleme
            );

            // Alınan DTO'lar view model'e dönüştürülür
            UserListViewResponseModel model = new()
            {
                Users = userDtos.Select(u => new UserViewResponseModel
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",     // Ad ve soyad birleştirilir
                    Email = u.Email,
                    Role = u.Role,
                    Address = u.Address,
                    Nationality = u.Nationality,
                    Gender = u.Gender,
                    IdentityNumber = u.IdentityNumber,
                    Status = u.Status
                }).ToList()
            };

            // View'e kullanıcı listesi gönderilir
            return View(model);
        }

        #endregion

        #region UserCreateAction

        /// <summary>
        /// Yeni kullanıcı oluşturma formunu hazırlar.
        /// Kullanılabilir roller dropdown olarak ViewBag üzerinden View'e aktarılır.
        /// Varsayılan rol "Member" olarak atanır.
        /// </summary>
        public async Task<IActionResult> Create()
        {
            // Mevcut rollerin listesini çekiyoruz
            List<string?> roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            // Varsayılan olarak "Member" rolü atanmış boş model hazırlanır
            CreateUserRequestModel model = new() { Role = "Member" };

            // Roller dropdown olarak ViewBag'e aktarılır
            ViewBag.Roles = new SelectList(roles);

            // Form View'e gönderilir
            return View(model);
        }

        /// <summary>
        /// Yeni kullanıcı oluşturma işlemini gerçekleştirir.
        /// Gelen form verileri doğrulanır, kullanıcı daha önce kayıtlı mı kontrol edilir,
        /// BLL üzerinden kullanıcı oluşturma işlemi gerçekleştirilir.
        /// </summary>
        /// <param name="model">Kullanıcı oluşturma formundan gelen model</param>
        /// <returns>İşlem sonucu: Başarılıysa Index sayfasına yönlendirme, aksi halde form tekrar gösterilir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserRequestModel model)
        {
            // Form doğrulaması başarısızsa form geri gösterilir
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }

            // Aynı e-posta adresi ile daha önce kullanıcı oluşturulmuş mu kontrol edilir
            AppUser? existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanımda.");
                ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }

            try
            {
                // Form modeli → DTO dönüşümü yapılır
                AppUserDto userDto = _mapper.Map<AppUserDto>(model);

                // Rol boşsa varsayılan "Member" atanır
                string role = string.IsNullOrWhiteSpace(model.Role) ? "Member" : model.Role;

                // BLL katmanındaki CreateUserWithProfileAsync metodu çağrılır
                AppUserDto createdUser = await _appUserManager.CreateUserWithProfileAsync(userDto, model.Password, role);

                // Başarı mesajı gösterilir
                TempData["SuccessMessage"] = "Kullanıcı başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                // Hata oluşursa mesaj gösterilir ve form tekrar döndürülür
                ModelState.AddModelError("", ex.Message);
                ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }
        }

        #endregion

        #region UserEdit

        /// <summary>
        /// Kullanıcı düzenleme formunu hazırlar.
        /// BLL'deki GetUserEditDataAsync metodu ile hem kullanıcı hem profil bilgileri çekilir.
        /// DTO, AutoMapper ile UpdateUserRequestModel'e dönüştürülür ve View'e gönderilir.
        /// </summary>
        /// <param name="id">Düzenlenecek kullanıcının ID'si</param>
        /// <returns>Düzenleme formu view'i</returns>
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                // Kullanıcı ve profil bilgileri DTO olarak alınır
                AppUserDto userDto = await _appUserManager.GetUserEditDataAsync(id);
                UpdateUserRequestModel model = _mapper.Map<UpdateUserRequestModel>(userDto);

                // Kullanıcının aktif/pasif durumu belirlenir
                model.IsActive = userDto.DeletedDate == null;

                // Kullanıcının rolü alınır
                List<string?> roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                AppUser? currentUser = await _userManager.FindByIdAsync(userDto.Id.ToString());
                IList<string> currentRoles = await _userManager.GetRolesAsync(currentUser);
                model.Role = currentRoles.FirstOrDefault(); // Kullanıcının mevcut rolü

                // Tüm roller dropdown için hazırlanır
                ViewBag.Roles = roles.Select(r => new SelectListItem
                {
                    Value = r,
                    Text = r,
                    Selected = (r == model.Role)
                }).ToList();

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// Kullanıcı düzenleme formu gönderildiğinde bilgileri günceller.
        /// Kullanıcı, profil ve rol bilgileri ayrı ayrı güncellenir.
        /// Ayrıca aktiflik durumu kontrol edilerek DeletedDate alanı yönetilir.
        /// </summary>
        /// <param name="model">Formdan gelen kullanıcı güncelleme modeli</param>
        /// <returns>Başarılıysa Index'e, değilse form view'ine döner</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserRequestModel model)
        {
            // Form verisi geçerli değilse form yeniden gösterilir
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

                return View(model);
            }

            // Güncellenecek kullanıcıyı bul
            AppUser? user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Kullanıcı bilgileri güncellenir
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.Email;
            user.ModifiedDate = DateTime.Now;
            user.Status = model.IsActive ? DataStatus.Inserted : DataStatus.Updated;

            IdentityResult updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı bilgileri güncellenirken bir hata oluştu.");
                return View(model);
            }

            // Kullanıcı profil bilgileri güncellenir
            AppUserProfileDto userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            if (userProfile != null)
            {
                userProfile.FirstName = model.FirstName;
                userProfile.LastName = model.LastName;
                userProfile.Address = model.Address;
                userProfile.Nationality = model.Nationality;
                userProfile.IdentityNumber = model.IdentityNumber;
                userProfile.Gender = model.Gender;
                userProfile.ModifiedDate = DateTime.Now;
                userProfile.Status = model.IsActive ? DataStatus.Inserted : DataStatus.Updated;

                await _appUserProfileManager.UpdateAsync(userProfile);
            }

            // Kullanıcının rolü değişmişse güncellenir
            IList<string>? currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(model.Role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            // Aktif/Pasif durumuna göre DeletedDate yönetilir
            if (model.IsActive)
            {
                user.DeletedDate = null;
                user.Status = DataStatus.Updated;

                if (userProfile != null)
                {
                    userProfile.DeletedDate = null;
                    userProfile.Status = DataStatus.Updated;
                    await _appUserProfileManager.UpdateAsync(userProfile);
                }
            }
            else
            {
                user.DeletedDate = DateTime.Now;
                user.Status = DataStatus.Deleted;

                if (userProfile != null)
                {
                    userProfile.DeletedDate = DateTime.Now;
                    userProfile.Status = DataStatus.Deleted;
                    await _appUserProfileManager.MakePassiveAsync(userProfile);
                }
            }

            // Değişiklikler kaydedilir
            await _userManager.UpdateAsync(user);
            TempData["SuccessMessage"] = "Kullanıcı başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region UserDelete

        /// <summary>
        /// Kullanıcı silme onay ekranını gösterir.
        /// Kullanıcıyı Identity üzerinden bulur, kendi hesabı olup olmadığını kontrol eder ve silme onayı view'ine kullanıcı bilgilerini taşır.
        /// </summary>
        /// <param name="id">Silinmek istenen kullanıcının ID'si</param>
        /// <returns>Silme onayı formunu içeren view</returns>
        public async Task<IActionResult> Delete(int id)
        {
            // Kullanıcı bilgisi Identity üzerinden alınır
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Oturum açan kullanıcı kendi hesabını silemez
            if (user.UserName == User.Identity.Name)
            {
                TempData["ErrorMessage"] = "Kendi hesabınızı silemezsiniz.";
                return RedirectToAction("Index");
            }

            // Kullanıcının rol bilgisi alınır (birden fazla rol varsa birleştirilir)
            IList<string>? roles = await _userManager.GetRolesAsync(user);
            string role = roles.Any() ? string.Join(", ", roles) : "Üye";

            // Kullanıcı bilgileri silme ekranı için modele aktarılır
            DeleteUserResponseModel model = new() 
            {
                Id = user.Id,
                FullName = $"{user.AppUserProfile?.FirstName} {user.AppUserProfile?.LastName}",
                Email = user.Email,
                Role = role
            };
            return View(model);
        }

        /// <summary>
        /// Kullanıcı silme işlemini gerçekleştirir.
        /// Kullanıcı kendi değilse ve sistemde mevcutsa, BLL aracılığıyla soft delete işlemi uygulanır.
        /// </summary>
        /// <param name="id">Silinmek istenen kullanıcının ID'si</param>
        /// <returns>Index'e yönlendirme yapılır</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Oturum açan kullanıcının ID'si alınır (kendi silmesini engellemek için kullanılabilir)
            int currentUserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            try
            {
                // BLL üzerinden kullanıcı ve profil pasif hale getirilir (soft delete)
                await _appUserManager.DeactivateUserAsync(id, currentUserId);
                TempData["SuccessMessage"] = "Kullanıcı başarıyla pasif duruma getirildi.";
            }
            catch (System.Exception ex)
            {
                // Hata oluşursa kullanıcıya mesaj gösterilir
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region UserChangePassword

        /// <summary>
        /// Kullanıcıya ait şifre değiştirme formunu hazırlar.
        /// </summary>
        /// <param name="id">Şifresi değiştirilecek kullanıcının ID'si</param>
        /// <returns>Şifre değiştirme formu view'i</returns>
        public async Task<IActionResult> ChangePassword(int id)
        {
            // ID ile kullanıcıyı veritabanından bul
            AppUser? user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Sadece ID'yi taşıyan model ile formu başlat
            ChangePasswordRequestModel model = new() 
            {
                Id = user.Id
            };

            return View(model);
        }

        /// <summary>
        /// Kullanıcının şifresini günceller.
        /// Mevcut şifre kontrolü yapılmaz, doğrudan reset işlemi uygulanır.
        /// </summary>
        /// <param name="model">Şifre değiştirme form modelidir</param>
        /// <returns>Başarılıysa listeye döner, aksi halde form tekrar gösterilir</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestModel model)
        {
            // Model doğrulaması yapılır
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanıcı tekrar veritabanından alınır
            AppUser? user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Mevcut şifre kontrolü yapılmaksızın sıfırlama token'ı üretilir
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Yeni şifre atanır
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

            // Hatalı durumlar kullanıcıya bildirilir
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Şifre güncellenemedi.");
                return View(model);
            }

            // Başarılı mesajı ve yönlendirme
            TempData["SuccessMessage"] = "Kullanıcının şifresi başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion
    }
}
