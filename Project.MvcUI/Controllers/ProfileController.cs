using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Entities.Models;
using Project.MvcUI.Models.PureVms.AppUsers.RequestModels;
using Project.MvcUI.Models.PureVms.AppUsers.ResponseModels;
using System.Threading.Tasks;

namespace Project.MvcUI.Controllers
{
    [Authorize] // Kullanıcı girişi zorunlu
    public class ProfileController : Controller
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(IAppUserManager appUserManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        // 📌 1️⃣ Kullanıcı Profili Görüntüleme
        public async Task<IActionResult> Index()
        {
            var userDto = await _appUserManager.GetUserProfileAsync(int.Parse(_userManager.GetUserId(User)));
            if (userDto == null) return RedirectToAction("Login", "Auth");

            var model = _mapper.Map<UserProfileResponseModel>(userDto);

            // **Eksik Gelen Bilgileri Manuel Olarak Atayalım**
            model.Gender = userDto.Gender.ToString();
            model.Nationality = userDto.Nationality;

            return View(model);
        }





        // 📌 2️⃣ Kullanıcı Profili Güncelleme - GET
        public async Task<IActionResult> Edit()
        {
            var userDto = await _appUserManager.GetUserProfileAsync(int.Parse(_userManager.GetUserId(User)));
            if (userDto == null) return RedirectToAction("Login", "Auth");

            var model = _mapper.Map<UserProfileUpdateRequestModel>(userDto);
            return View(model);
        }

        // 📌 2️⃣ Kullanıcı Profili Güncelleme - POST
        [HttpPost]
        public async Task<IActionResult> Edit(UserProfileUpdateRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userDto = await _appUserManager.GetUserProfileAsync(int.Parse(_userManager.GetUserId(User)));
            if (userDto == null) return RedirectToAction("Login", "Auth");

            // **Tüm Bilgileri DTO'ya Aktaralım**
            _mapper.Map(model, userDto);

            bool updateSuccess = await _appUserManager.UpdateUserProfileAsync(userDto);

            if (updateSuccess)
            {
                TempData["SuccessMessage"] = "Profil başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Profil güncellenirken hata oluştu.");
            return View(model);
        }




        // 📌 3️⃣ Kullanıcı Şifre Değiştirme - GET
        public IActionResult ChangePassword()
        {
            return View();
        }

        // 📌 3️⃣ Kullanıcı Şifre Değiştirme - POST
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordRequestModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = int.Parse(_userManager.GetUserId(User)); // Kullanıcı ID'sini al
            var result = await _appUserManager.ChangeUserPasswordAsync(userId, model.CurrentPassword, model.NewPassword);

            if (result)
            {
                TempData["Message"] = "Şifreniz başarıyla değiştirildi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Şifre değiştirme sırasında hata oluştu.";
            return View(model);
        }


    }
}
