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
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // 🔐 Sadece Admin yetkisi olanlar erişebilir
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager; // 🔥 Burada IdentityRole<int> olmalı!
        private readonly IAppUserManager _appUserManager;
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IAppUserProfileManager appUserProfileManager, IAppUserManager appUserManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager; // 🔥 IdentityRole<int> olarak düzeltildi!
            _appUserProfileManager = appUserProfileManager;
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        #region UserIndexAction

        public async Task<IActionResult> Index(UserIndexRequestModel request)
        {
            // BLL'den, filtre parametrelerine göre detayları tamamlanmış kullanıcı listesini alıyoruz
            List<AppUserDto> userDtos = await _appUserManager.GetUsersWithDetailsAsync(
                request.Search,
                request.Role,
                request.Status
            );

            // DTO'ları UI modeline dönüştürüyoruz
            UserListViewResponseModel model = new()
            {
                Users = userDtos.Select(u => new UserViewResponseModel
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Email = u.Email,
                    Role = u.Role,
                    Address = u.Address,
                    Nationality = u.Nationality,
                    Gender = u.Gender,
                    IdentityNumber = u.IdentityNumber,
                    Status = u.Status
                }).ToList()
            };

            return View(model);
        }

        #endregion

        #region UserCreateAction

        public async Task<IActionResult> Create()
        {
            // Mevcut rollerin listesini çekiyoruz
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            // Varsayılan rol "Member" olarak ayarlanıyor
            var model = new CreateUserRequestModel { Role = "Member" };
            ViewBag.Roles = new SelectList(roles);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse, roller listesini tekrar yükleyip view'e geri dönüyoruz
                ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }

            // Aynı e-posta adresine sahip kullanıcı kontrolü
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanımda.");
                ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }

            try
            {
                // CreateUserRequestModel'den AppUserDto'ya mapping yapıyoruz
                var userDto = _mapper.Map<AppUserDto>(model);
                // Rol boş ise varsayılan olarak "Member" atanıyor
                string role = string.IsNullOrWhiteSpace(model.Role) ? "Member" : model.Role;

                // BLL'deki merkezi metodu kullanarak kullanıcı oluşturma, rol atama ve profil oluşturma işlemleri gerçekleştiriliyor
                var createdUser = await _appUserManager.CreateUserWithProfileAsync(userDto, model.Password, role);

                TempData["SuccessMessage"] = "Kullanıcı başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                // Hata durumunda ModelState'e hata mesajı eklenip roller yeniden yükleniyor
                ModelState.AddModelError("", ex.Message);
                ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }
        }

        #endregion

        #region UserEdit

        /// <summary>
        /// GET: Kullanıcı düzenleme formunu hazırlar.
        /// BLL'deki GetUserEditDataAsync metodu kullanılarak, kullanıcı, profil ve rol bilgilerini içeren AppUserDto elde edilir.
        /// Bu DTO, AutoMapper aracılığıyla UpdateUserRequestModel'e dönüştürülür ve form view'üne gönderilir.
        /// </summary>
        /// <param name="id">Düzenlenecek kullanıcının ID'si</param>
        /// <returns>UpdateUserRequestModel içeren düzenleme formu view'i</returns>
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                // BLL'deki merkezi metot ile kullanıcı verilerini alıyoruz
                AppUserDto userDto = await _appUserManager.GetUserEditDataAsync(id);

                // Eğer DTO ile ViewModel arasında farklılık varsa, AutoMapper kullanarak dönüştürüyoruz
                var model = _mapper.Map<UpdateUserRequestModel>(userDto);

                // Tüm rolleri çekip, mevcut rolün seçili olduğu SelectList oluşturuluyor
                var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                ViewBag.Roles = new SelectList(roles, model.Role);

                return View(model);
            }
            catch (System.Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// POST: Kullanıcı güncelleme işlemini gerçekleştirir.
        /// BLL'deki UpdateUserWithProfileAsync metodu kullanılarak, gelen AppUserDto bilgileri ile kullanıcı ve profil güncellenir.
        /// </summary>
        /// <param name="model">Kullanıcı güncelleme formundan gelen verileri içeren UpdateUserRequestModel</param>
        /// <returns>Güncelleme başarılı ise Index'e yönlendirir, aksi halde form view'ünü yeniden render eder.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Roles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

                return View(model);
            }

            // 🔍 Güncellenecek kullanıcıyı bul
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ Kullanıcı Bilgilerini Güncelle
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            user.UserName = model.Email; // Kullanıcı adı e-posta ile aynı olacak
            user.ModifiedDate = DateTime.Now;
            user.Status = model.IsActive ? DataStatus.Inserted : DataStatus.Updated;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı bilgileri güncellenirken bir hata oluştu.");
                return View(model);
            }

            // ✅ Kullanıcı Profilini Güncelle
            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
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

            // ✅ Rolü Güncelle
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(model.Role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles); // Eski rolleri kaldır
                await _userManager.AddToRoleAsync(user, model.Role); // Yeni rolü ata
            }
            // 🔥 **Kullanıcıyı Aktif / Pasif Yap**
            if (model.IsActive)
            {
                user.DeletedDate = null; // Kullanıcıyı aktif yap
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
                user.DeletedDate = DateTime.Now; // Kullanıcıyı pasif yap
                user.Status = DataStatus.Deleted;

                if (userProfile != null)
                {
                    userProfile.DeletedDate = DateTime.Now;
                    userProfile.Status = DataStatus.Deleted;
                    await _appUserProfileManager.MakePassiveAsync(userProfile);
                }
            }
            await _userManager.UpdateAsync(user); // Son değişiklikleri kaydet
            TempData["SuccessMessage"] = "Kullanıcı başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion

        #region UserDelete

        public async Task<IActionResult> Delete(int id)
        {
            // Kullanıcıyı Identity üzerinden çekiyoruz.
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Admin, kendi hesabını silemez!
            if (user.UserName == User.Identity.Name)
            {
                TempData["ErrorMessage"] = "Kendi hesabınızı silemezsiniz.";
                return RedirectToAction("Index");
            }

            // Kullanıcının rollerini alıyoruz.
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.Any() ? string.Join(", ", roles) : "Üye";

            // Kullanıcı bilgilerini DeleteUserResponseModel'e taşıyoruz.
            var model = new DeleteUserResponseModel
            {
                Id = user.Id,
                FullName = $"{user.AppUserProfile?.FirstName} {user.AppUserProfile?.LastName}",
                Email = user.Email,
                Role = role
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Oturum açan kullanıcının ID'sini alıyoruz.
            int currentUserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);

            try
            {
                // BLL'deki merkezi metodu çağırarak kullanıcıyı ve profilini pasif hale getiriyoruz.
                await _appUserManager.DeactivateUserAsync(id, currentUserId);
                TempData["SuccessMessage"] = "Kullanıcı başarıyla pasif duruma getirildi.";
            }
            catch (System.Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region UserChangePassword

        // GET: ChangePassword
        public async Task<IActionResult> ChangePassword(int id)
        {
            // Kullanıcı mevcut mi diye kontrol ediyorsanız:
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Formda sadece Id yeterli olabilir
            var model = new ChangePasswordRequestModel
            {
                Id = user.Id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // BLL katmanındaki şifre değiştirme metodunu çağırıyoruz
            bool isChanged = await _appUserManager.ChangeUserPasswordAsync(
                model.Id,
                model.CurrentPassword,
                model.NewPassword
            );

            if (!isChanged)
            {
                ModelState.AddModelError("", "Şifre değiştirilirken bir hata oluştu veya eski şifre hatalı.");
                return View(model);
            }

            TempData["SuccessMessage"] = "Kullanıcının şifresi başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        #endregion
    }
}
