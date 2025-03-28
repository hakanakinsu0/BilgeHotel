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
        Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword);
        Task<int> GetTotalUserCountAsync(); // Toplam kullanıcı sayısı.
        Task<int> GetActiveUserCountAsync(); // Aktif kullanıcı sayısı.
        Task<AppUser?> FindUserByEmailAsync(string email); // Kullanıcının email adresine göre var olup olmadığını kontrol eder.
        Task<IdentityResult> CreateUserAsync(AppUser user, string password); // Yeni kullanıcı nesnesini oluşturur.
        Task<IdentityResult> AssignRoleAsync(AppUser user, string roleName); // Rol atama işlemi.
        Guid GenerateActivationCode();  // Aktivasyon kodu üretir.
        Task SendActivationEmailAsync(AppUser user, Guid activationCode); //Aktivasyon mailini gönderir.
        Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode); //Email onaylama işlemini gerçekleştirir.
        Task<IdentityResult> SendPasswordResetEmailAsync(string email); //Şifre sıfırlama mailini gönderir.
        Task<(AppUserDto user, AppUserProfileDto profile)> GetUserWithProfileAsync(string username);

        Task<(int TotalCustomers, int CustomersWithReservations, int CustomersWithoutReservations, List<AppUserDto> Members, List<AppUserProfileDto> Profiles, List<ReservationDto> Reservations)> GetCustomerReportDataAsync();


        /// <summary>
        /// Tüm kullanıcıları, ilgili profil ve rol bilgileriyle birlikte getirir ve verilen filtre parametrelerine göre filtreler.
        /// Bu metot sayesinde controller, kullanıcı detaylarını çekme ve filtreleme işlemlerini BLL üzerinden gerçekleştirebilir.
        /// </summary>
        /// <param name="search">Kullanıcı adı, soyadı, email veya kullanıcı adı araması</param>
        /// <param name="role">Rol filtresi</param>
        /// <param name="status">Kullanıcı durumu filtresi ("Aktif", "Pasif")</param>
        /// <returns>Filtrelenmiş ve detayları tamamlanmış AppUserDto listesini asenkron olarak döndürür.</returns>
        Task<List<AppUserDto>> GetUsersWithDetailsAsync(string search, string role, string status);

        /// <summary>
        /// Yeni kullanıcıyı DTO üzerinden oluşturur, Identity sistemine kaydeder, kullanıcıya rol atar ve kullanıcı profilini oluşturur.
        /// </summary>
        /// <param name="userDto">Kullanıcı bilgilerini içeren AppUserDto</param>
        /// <param name="password">Kullanıcının şifresi</param>
        /// <param name="role">Atanacak rol (varsayılan "Member")</param>
        /// <returns>Oluşturulan kullanıcıya ait AppUserDto</returns>
        Task<AppUserDto> CreateUserWithProfileAsync(AppUserDto userDto, string password, string role = "Member");

        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre, kullanıcı bilgileri, profil bilgileri ve roller birleştirilerek
        /// düzenleme için gerekli UpdateUserRequestModel oluşturulur.
        /// </summary>
        /// <param name="userId">Düzenlenecek kullanıcının ID'si</param>
        /// <returns>UpdateUserRequestModel nesnesi</returns>
        Task<AppUserDto> GetUserEditDataAsync(int userId);

        /// <summary>
        /// Belirtilen kullanıcıyı, ilgili profil bilgileriyle birlikte pasif (soft-delete) duruma getirir.
        /// Kullanıcı pasif ise işlem iptal edilir.
        /// Admin, kendi hesabını silemez.
        /// </summary>
        /// <param name="userId">Pasif duruma getirilecek kullanıcının ID'si</param>
        /// <param name="currentUserId">Şu anki oturum açmış kullanıcı ID'si (kendi hesabını silmemek için)</param>
        /// <returns>İşlemin başarılı olup olmadığını belirten boolean değer</returns>
        Task<bool> DeactivateUserAsync(int userId, int currentUserId);

    }
}
