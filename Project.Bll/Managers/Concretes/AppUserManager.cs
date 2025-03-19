using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using Project.Common.Tools;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// AppUser ile ilgili iş mantığı işlemlerini yöneten manager sınıfı. 
    /// BaseManager üzerinden temel CRUD işlemlerini kullanır.
    /// </summary>
    public class AppUserManager : BaseManager<AppUserDto, AppUser>, IAppUserManager
    {
        const string BaseUrl = "http://localhost:5114"; // Manager için sabit URL

        readonly IAppUserRepository _repository; // Repository bağımlılığı
        readonly IAppUserProfileManager _appUserProfileManager; // Profil manager bağımlılığı
        readonly IMapper _mapper; // AutoMapper bağımlılığı
        readonly UserManager<AppUser> _userManager; // UserManager bağımlılığı
        readonly RoleManager<IdentityRole<int>> _roleManager; // Rol yönetimi bağımlılığı


        public AppUserManager(
            IAppUserRepository repository,
            IAppUserProfileManager appUserProfileManager,
            IMapper mapper,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole<int>> roleManager)
            : base(repository, mapper)
        {
            _repository = repository;
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Kullanıcının şifresini değiştirir.
        /// </summary>
        public async Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword)
        {
            AppUser? user = await _repository.GetByIdAsync(userId); // Kullanıcıyı ID'ye göre getir 

            if (user == null) return false;                     // Eğer kullanıcı bulunamazsa false döndür 

            IdentityResult? result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword); // Şifre değiştir 

            if (result.Succeeded) // Değişim başarılı ise
            {
                user.ModifiedDate = DateTime.Now; // ModifiedDate güncelle
                user.Status = DataStatus.Updated; // Status güncelle

                await _repository.UpdateAsync(user, user); // Repository üzerinden güncelleme yap
                return true; // True döndür
            }

            return false; // Aksi halde false döndür
        }

        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre kullanıcı profilini getirir.
        /// </summary>
        public async Task<AppUserDto> GetUserProfileAsync(int userId)
        {
            AppUser? user = await _repository.GetByIdAsync(userId); // Kullanıcıyı getir

            if (user == null) return null; // Kullanıcı yoksa null döndür

            AppUserDto? userDto = _mapper.Map<AppUserDto>(user); // Kullanıcıyı DTO'ya map et

            // Profil bilgileri mevcutsa DTO'ya ekle
            if (user.AppUserProfile != null) // Eğer profil bilgisi varsa atamaları yap.
            {
                userDto.FirstName = user.AppUserProfile.FirstName;
                userDto.LastName = user.AppUserProfile.LastName;
                userDto.Address = user.AppUserProfile.Address;
                userDto.Gender = user.AppUserProfile.Gender;
                userDto.Nationality = user.AppUserProfile.Nationality;
                userDto.IdentityNumber = user.AppUserProfile.IdentityNumber;

            }
            return userDto; // DTO döndür
        }

        /// <summary>
        /// Kullanıcı profilini günceller.
        /// </summary>
        public async Task<bool> UpdateUserProfileAsync(AppUserDto userDto)
        {
            AppUser? user = await _repository.GetByIdAsync(userDto.Id);  // Kullanıcıyı getir

            if (user == null) return false; // Kullanıcı yoksa false döndür

            // AppUser güncelleme
            _mapper.Map(userDto, user); // DTO'yu entity'e map et
            user.NormalizedEmail = userDto.Email.ToUpper(); // Email normalize et
            user.SecurityStamp = Guid.NewGuid().ToString(); // SecurityStamp oluştur
            user.ModifiedDate = DateTime.Now; // ModifiedDate güncelle
            user.Status = DataStatus.Updated; // Status güncelle

            // AppUserProfile güncelleme veya ekleme
            if (user.AppUserProfile != null) // Eğer profil bilgisi mevcutsa atamaları yap
            {
                user.AppUserProfile.FirstName = userDto.FirstName;
                user.AppUserProfile.LastName = userDto.LastName;
                user.AppUserProfile.Address = userDto.Address;
                user.AppUserProfile.Gender = userDto.Gender;
                user.AppUserProfile.Nationality = userDto.Nationality;
                user.AppUserProfile.IdentityNumber = userDto.IdentityNumber;
                user.AppUserProfile.ModifiedDate = DateTime.Now;
                user.AppUserProfile.Status = DataStatus.Updated;

                await _appUserProfileManager.UpdateAsync(_mapper.Map<AppUserProfileDto>(user.AppUserProfile)); // Profil güncelle
            }
            else
            {
                AppUserProfileDto? newProfile = new AppUserProfileDto // Yeni profil oluştur ve atamaları yap
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Address = userDto.Address,
                    Gender = userDto.Gender,
                    Nationality = userDto.Nationality,
                    IdentityNumber = userDto.IdentityNumber,
                    AppUserId = userDto.Id,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                };

                await _appUserProfileManager.CreateAsync(newProfile); // Yeni profil oluştur
            }

            await _repository.UpdateAsync(user, user); // Kullanıcıyı güncelle
            return true; // True döndür
        }

        /// <summary>
        /// Toplam kullanıcı sayısını getirir.
        /// </summary>
        public async Task<int> GetTotalUserCountAsync()
        {
            return await CountAsync(); // BaseManager'dan CountAsync çağrısı
        }

        /// <summary>
        /// Aktif kullanıcı sayısını getirir.
        /// </summary>
        public async Task<int> GetActiveUserCountAsync()
        {
            return await CountAsync(u => u.Status == DataStatus.Inserted || u.Status == DataStatus.Updated);  // Aktif kullanıcı sayısını filtreleyerek getir
        }

        /// <summary>
        /// Belirtilen email adresine göre kullanıcıyı bulur.
        /// </summary>
        public async Task<AppUser?> FindUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email); // UserManager üzerinden email ile kullanıcı getir
        }

        /// <summary>
        /// Yeni kullanıcı oluşturur.
        /// </summary>
        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password); // UserManager üzerinden kullanıcı oluştur
        }

        /// <summary>
        /// Belirtilen role kullanıcı ataması yapar.
        /// </summary>
        public async Task<IdentityResult> AssignRoleAsync(AppUser user, string roleName)
        {
            IdentityRole<int> role = await _roleManager.FindByNameAsync(roleName); // Rolü bul
            if (role == null) // Rol yoksa
            {
                IdentityResult createRoleResult = await _roleManager.CreateAsync(new IdentityRole<int> { Name = roleName }); // Rol oluştur
                if (!createRoleResult.Succeeded) return createRoleResult;  // Oluşturma başarısızsa sonucu döndür
            }
            return await _userManager.AddToRoleAsync(user, roleName); // Kullanıcıya rol ata
        }

        /// <summary>
        /// Yeni bir aktivasyon kodu üretir.
        /// </summary>
        public Guid GenerateActivationCode()
        {
            return Guid.NewGuid(); // Yeni GUID üret
        }

        /// <summary>
        /// Aktivasyon mailini gönderir.
        /// </summary>
        public async Task SendActivationEmailAsync(AppUser user, Guid activationCode)
        {
            string emailBody = $"<p>Hesabınız oluşturulmuştur. Üyeliğinizi tamamlamak için aşağıdaki bağlantıya tıklayınız:</p><p><a href='{BaseUrl}/Auth/ConfirmEmail?activationCode={activationCode}&userId={user.Id}' style='color:blue; text-decoration:underline;'>E-posta doğrulama bağlantısı</a></p>"; // Mail bodysini hazırla

            await MailService.SendAsync(user.Email, body: emailBody, subject: "BilgeHotel Aktivasyon Maili"); // Mail gönderimini asenkron gerçekleştir
        }

        /// <summary>
        /// Email onaylama işlemini gerçekleştirir.
        /// </summary>
        public async Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId.ToString()); // Kullanıcıyı ID ile bul
            if (user == null)  // Eğer kullanıcı bulunamazsa
            {
                //throw new Exception("Kullanıcı bulunamadı."); // Exception fırlat
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
            }

            if (user.ActivationCode != activationCode) // Aktivasyon kodu kontrolü
            {
                return IdentityResult.Failed(new IdentityError { Description = "Geçersiz doğrulama kodu." });
            }

            user.EmailConfirmed = true; // Email doğrulama onaylandı
            user.ModifiedDate = DateTime.Now; // ModifiedDate güncelle
            user.Status = DataStatus.Updated; // Status güncelle

            return await _userManager.UpdateAsync(user); // Kullanıcıyı güncelle ve sonucu döndür
        }

        /// <summary>
        /// Şifre sıfırlama mailini gönderir.
        /// </summary>
        public async Task<IdentityResult> SendPasswordResetEmailAsync(string email)
        {
            // Kullanıcıyı email ile bul
            AppUser user = await _userManager.FindByEmailAsync(email); // Email ile kullanıcıyı bul

            if (user == null) // Kullanıcı bulunamazsa
            {
                return IdentityResult.Failed(new IdentityError {Description = "Kullanıcı bulunamadı."}); // Hata mesajını döndür
            }

            if (!await _userManager.IsEmailConfirmedAsync(user)) // Email onayı kontrolü
            {
                return IdentityResult.Failed(new IdentityError{Description = "E-posta onaylı değil."}); // Hata mesajını döndür
            }

            string emailBody = $"<p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p><p><a href='{BaseUrl}/Auth/ResetPassword?token={Uri.EscapeDataString(await _userManager.GeneratePasswordResetTokenAsync(user))}&email={Uri.EscapeDataString(user.Email)}' style='color:blue; text-decoration:underline;'>Şifreyi Sıfırla</a></p>";
            // E-posta içeriğini oluştur

            await MailService.SendAsync(user.Email, body: emailBody, subject: "BilgeHotel Şifre Sıfırlama"); // Mail gönderimini asenkron gerçekleştir

            return IdentityResult.Success; // Başarılı sonucu döndür
        }
    }
}
