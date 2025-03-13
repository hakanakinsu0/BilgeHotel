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
using Project.MvcUI.Areas.Admin.Models.RequestModels;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // 🔐 Sadece Admin yetkisi olanlar erişebilir
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager; // 🔥 Burada IdentityRole<int> olmalı!
        private readonly IAppUserProfileManager _appUserProfileManager;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager, IAppUserProfileManager appUserProfileManager)
        {
            _userManager = userManager;
            _roleManager = roleManager; // 🔥 IdentityRole<int> olarak düzeltildi!
            _appUserProfileManager = appUserProfileManager;
        }


        public async Task<IActionResult> Index(string search, string role, string status)
        {
            var users = await _userManager.Users.ToListAsync(); // **Tüm kullanıcıları çekiyoruz**
            var userList = new List<AppUserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user); // **Kullanıcının rollerini alıyoruz**
                var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id); // **AppUserId ile doğru profili çekiyoruz**

                userList.Add(new AppUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    Role = roles.Any() ? string.Join(", ", roles) : "Üye", // **Varsayılan rol "Üye"**

                    // **Profil Bilgileri (Doğru AppUserId ile eşleşme yapıldı!)**
                    FirstName = userProfile?.FirstName ?? "-", // 🔥 İlk isim buradan gelecek
                    LastName = userProfile?.LastName ?? "-", // 🔥 Soyisim buradan gelecek
                    Address = userProfile?.Address ?? "-",
                    Nationality = userProfile?.Nationality ?? "-",
                    Gender = userProfile?.Gender ?? Gender.Other,
                    IdentityNumber = userProfile?.IdentityNumber ?? "-",

                    Status = user.Status
                });
            }

            // **Filtreleme**
            if (!string.IsNullOrEmpty(search))
            {
                userList = userList.Where(u =>
                    u.FirstName.Contains(search) ||
                    u.LastName.Contains(search) ||
                    u.Email.Contains(search) ||
                    u.UserName.Contains(search)).ToList();
            }

            if (!string.IsNullOrEmpty(role))
            {
                userList = userList.Where(u => u.Role.Contains(role)).ToList();
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Aktif") userList = userList.Where(u => u.Status != DataStatus.Deleted).ToList();
                if (status == "Pasif") userList = userList.Where(u => u.Status == DataStatus.Deleted).ToList();
            }

            var model = new UserListViewModel
            {
                Users = userList.Select(u => new UserViewModel
                {
                    Id = u.Id,
                    FullName = $"{u.FirstName} {u.LastName}",
                    Email = u.Email,
                    Role = u.Role,
                    //Status = u.EmailConfirmed ? DataStatus.Inserted : DataStatus.Deleted,
                    Address = u.Address,
                    Nationality = u.Nationality,
                    Gender = u.Gender,
                    IdentityNumber = u.IdentityNumber,
                    Status = u.Status
                }).ToList()
            };

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync(); // Mevcut rollerin listesini çekiyoruz.

            var model = new CreateUserRequestModel
            {
                Role = "Member" // Varsayılan olarak kullanıcı rolünü "Member" yapıyoruz.
            };

            ViewBag.Roles = new SelectList(roles); // Rol listesini ViewBag ile gönderiyoruz.

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        Console.WriteLine($"ModelState Hatası - {key}: {error.ErrorMessage}");
                    }
                }

                ViewBag.Roles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();

                return View(model);
            }


            // ✅ Aynı e-posta adresine sahip kullanıcı olup olmadığını kontrol et
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Bu e-posta adresi zaten kullanımda.");
                return View(model);
            }

            Guid activationCode = Guid.NewGuid();


            // ✅ Yeni Kullanıcıyı Oluştur
            var newUser = new AppUser
            {
                ActivationCode = activationCode,
                UserName = string.IsNullOrWhiteSpace(model.UserName) ? model.Email : model.UserName, // Eğer boşsa e-posta ile doldur
                Email = model.Email,
                EmailConfirmed = true,
                PhoneNumber = model.PhoneNumber,
                PhoneNumberConfirmed = false,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // ✅ Kullanıcıyı Identity sistemine kaydet
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            // ✅ Kullanıcıya Rol Ata
            if (!string.IsNullOrEmpty(model.Role))
            {
                var roleExists = await _roleManager.RoleExistsAsync(model.Role);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole<int> { Name = model.Role });
                }

                await _userManager.AddToRoleAsync(newUser, model.Role);
            }

            // ✅ Kullanıcı Profili Oluştur
            var userProfileDto = new AppUserProfileDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = string.IsNullOrWhiteSpace(model.Address) ? "Adres belirtilmedi" : model.Address,
                Nationality = model.Nationality,
                IdentityNumber = model.IdentityNumber,
                Gender = model.Gender,
                AppUserId = newUser.Id,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            Console.WriteLine($"Profil Verisi: {Newtonsoft.Json.JsonConvert.SerializeObject(userProfileDto)}");

            await _appUserProfileManager.CreateAsync(userProfileDto);



            TempData["SuccessMessage"] = "Kullanıcı başarıyla eklendi.";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // 1️⃣ Kullanıcıyı Identity üzerinden bul
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("Index");
            }

            // 2️⃣ Kullanıcının profil bilgilerini çek
            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);

            // 3️⃣ Kullanıcının mevcut rollerini al
            var userRoles = await _userManager.GetRolesAsync(user);

            // 4️⃣ Sistemdeki tüm rolleri liste olarak çek
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            // 5️⃣ Kullanıcı bilgilerini ViewModel'e taşı
            var model = new UpdateUserRequestModel
            {
                Id = user.Id,
                FirstName = userProfile?.FirstName ?? "-",
                LastName = userProfile?.LastName ?? "-",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = userProfile?.Address ?? "-",
                Nationality = userProfile?.Nationality ?? "-",
                IdentityNumber = userProfile?.IdentityNumber ?? "-",
                Gender = userProfile?.Gender ?? Gender.Other,
                Role = userRoles.Any() ? userRoles.First() : "Member" // Varsayılan olarak "Member" seçili gelsin
            };

            // 6️⃣ Rolleri ViewBag ile View'e gönder
            ViewBag.Roles = new SelectList(roles, model.Role);

            return View(model);
        }


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


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            // Kullanıcıyı getir
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // Admin kendi hesabını silemez!
            if (user.UserName == User.Identity.Name)
            {
                TempData["ErrorMessage"] = "Kendi hesabınızı silemezsiniz.";
                return RedirectToAction("Index");
            }

            // Kullanıcının rollerini al
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.Any() ? string.Join(", ", roles) : "Üye";

            // ViewModel ile onay sayfasına gönder
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
            // 🔥 Kullanıcıyı veritabanından bul
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("Index");
            }

            // 🔥 Admin kendi hesabını silemez!
            var currentUserId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            if (user.Id == currentUserId)
            {
                TempData["ErrorMessage"] = "Kendi hesabınızı silemezsiniz!";
                return RedirectToAction("Index");
            }

            // 🔥 Kullanıcı zaten pasif mi? (Zaten silindiyse işlem iptal)
            if (user.Status == DataStatus.Deleted)
            {
                TempData["ErrorMessage"] = "Bu kullanıcı zaten pasif durumda.";
                return RedirectToAction("Index");
            }

            // 🔥 Kullanıcıyı PASİF duruma getir
            user.Status = DataStatus.Deleted;
            user.DeletedDate = DateTime.Now;
            await _userManager.UpdateAsync(user);

            // 🔥 Kullanıcının PROFİL bilgilerini de pasife çek
            var userProfile = await _appUserProfileManager.GetByAppUserIdAsync(user.Id);
            if (userProfile != null)
            {
                userProfile.Status = DataStatus.Deleted;
                userProfile.DeletedDate = DateTime.Now;
                await _appUserProfileManager.MakePassiveAsync(userProfile);
            }

            TempData["SuccessMessage"] = "Kullanıcı başarıyla pasif duruma getirildi.";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> ChangePassword(int id)
        {
            // 🔍 Kullanıcıyı bul
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ Modeli View'e gönderiyoruz
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

            // 🔍 Kullanıcıyı bul
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (user == null)
            {
                TempData["ErrorMessage"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            // ✅ Yeni şifreyi hashleyerek kaydet
            var newPasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
            user.PasswordHash = newPasswordHash;
            user.ModifiedDate = DateTime.Now;
            user.Status = DataStatus.Updated;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Şifre değiştirilirken bir hata oluştu.");
                return View(model);
            }

            TempData["SuccessMessage"] = "Kullanıcının şifresi başarıyla güncellendi.";
            return RedirectToAction("Index");
        }


    }
}
