using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Project.Bll.DtoClasses;
using Project.Entities.Models;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// AppUser ile ilgili işlemleri tanımlayan manager arayüzü. AppUser işlemlerini tanımlar.
    /// </summary>
    public interface IAppUserManager : IManager<AppUserDto, AppUser>
    {
        Task<AppUserDto> GetUserProfileAsync(int userId); // Kullanıcı profilini getirir.
        Task<bool> UpdateUserProfileAsync(AppUserDto userDto); // Profil güncelleme işlemi
        Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword); // Şifre değiştirme işlemi
        Task<int> GetTotalUserCountAsync(); // Toplam kullanıcı sayısı.
        Task<int> GetActiveUserCountAsync(); // Aktif kullanıcı sayısı.
        Task<AppUser?> FindUserByEmailAsync(string email); // Kullanıcının email adresine göre var olup olmadığını kontrol eder.
        Task<IdentityResult> CreateUserAsync(AppUser user, string password); // Yeni kullanıcı nesnesini oluşturur.
        Task<IdentityResult> AssignRoleAsync(AppUser user, string roleName); // Rol atama işlemi.
        Guid GenerateActivationCode();  // Aktivasyon kodu üretir.
        Task SendActivationEmailAsync(AppUser user, Guid activationCode); //Aktivasyon mailini gönderir.
        Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode); //Email onaylama işlemini gerçekleştirir.
        Task<IdentityResult> SendPasswordResetEmailAsync(string email); //Şifre sıfırlama mailini gönderir. 
    }
}
