using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System.Collections.Generic;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// AppUser ile ilgili işlemleri tanımlayan manager interface'idir.
    /// Bu arayüz, kullanıcı oluşturma, güncelleme, şifre değiştirme, rol atama, e-posta aktivasyonu,
    /// şifre sıfırlama, kullanıcı raporları ve filtreleme gibi işlemleri kapsar.
    /// </summary>
    public interface IAppUserManager : IManager<AppUserDto, AppUser>
    {
        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre kullanıcı profil bilgilerini getirir.
        /// </summary>
        /// <param name="userId">Kullanıcı ID'si.</param>
        /// <returns>Kullanıcı profil bilgilerini taşıyan AppUserDto.</returns>
        Task<AppUserDto> GetUserProfileAsync(int userId);

        /// <summary>
        /// Belirtilen kullanıcı profil bilgilerini günceller.
        /// </summary>
        /// <param name="userDto">Güncellenecek kullanıcı bilgilerini içeren AppUserDto.</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> UpdateUserProfileAsync(AppUserDto userDto);

        /// <summary>
        /// Kullanıcının mevcut şifresini yeni bir şifre ile değiştirir.
        /// </summary>
        /// <param name="userId">Kullanıcı ID'si.</param>
        /// <param name="currentPassword">Mevcut şifre.</param>
        /// <param name="newPassword">Yeni şifre.</param>
        /// <returns>Şifre değişikliği işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> ChangeUserPasswordAsync(int userId, string currentPassword, string newPassword);

        /// <summary>
        /// Tüm kullanıcıların sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Toplam kullanıcı sayısı.</returns>
        Task<int> GetTotalUserCountAsync();

        /// <summary>
        /// Aktif kullanıcıların sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Aktif kullanıcı sayısı.</returns>
        Task<int> GetActiveUserCountAsync();

        /// <summary>
        /// Belirtilen e-posta adresine sahip kullanıcıyı asenkron olarak bulur.
        /// </summary>
        /// <param name="email">Kullanıcının e-posta adresi.</param>
        /// <returns>Bulunan AppUser nesnesi veya null.</returns>
        Task<AppUser?> FindUserByEmailAsync(string email);

        /// <summary>
        /// Yeni bir kullanıcı oluşturur ve Identity sistemi üzerinden kaydeder.
        /// </summary>
        /// <param name="user">Oluşturulacak AppUser nesnesi.</param>
        /// <param name="password">Kullanıcının şifresi.</param>
        /// <returns>Kullanıcı oluşturma işleminin sonucunu içeren IdentityResult.</returns>
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);

        /// <summary>
        /// Belirtilen role kullanıcı ataması yapar.
        /// </summary>
        /// <param name="user">Rol ataması yapılacak AppUser nesnesi.</param>
        /// <param name="roleName">Atanacak rolün adı.</param>
        /// <returns>Rol atama işleminin sonucunu içeren IdentityResult.</returns>
        Task<IdentityResult> AssignRoleAsync(AppUser user, string roleName);

        /// <summary>
        /// Yeni bir aktivasyon kodu üretir.
        /// </summary>
        /// <returns>Üretilen aktivasyon kodu (GUID).</returns>
        Guid GenerateActivationCode();

        /// <summary>
        /// Kullanıcıya aktivasyon maili gönderir.
        /// </summary>
        /// <param name="user">Aktivasyon maili gönderilecek AppUser nesnesi.</param>
        /// <param name="activationCode">Aktivasyon kodu.</param>
        /// <returns>Asenkron işlem.</returns>
        Task SendActivationEmailAsync(AppUser user, Guid activationCode);

        /// <summary>
        /// Kullanıcının e-posta onaylama işlemini gerçekleştirir.
        /// </summary>
        /// <param name="userId">Onaylanacak kullanıcının ID'si.</param>
        /// <param name="activationCode">Aktivasyon kodu.</param>
        /// <returns>E-posta onaylama işleminin sonucunu içeren IdentityResult.</returns>
        Task<IdentityResult> ConfirmEmailAsync(int userId, Guid activationCode);

        /// <summary>
        /// Kullanıcının şifre sıfırlama mailini gönderir.
        /// </summary>
        /// <param name="email">Şifre sıfırlama maili gönderilecek e-posta adresi.</param>
        /// <returns>Şifre sıfırlama mailinin gönderilme sonucunu içeren IdentityResult.</returns>
        Task<IdentityResult> SendPasswordResetEmailAsync(string email);

        /// <summary>
        /// Belirtilen kullanıcı adını kullanarak, kullanıcı ve profil bilgilerini birlikte getirir.
        /// </summary>
        /// <param name="username">Kullanıcının kullanıcı adı.</param>
        /// <returns>Kullanıcı ve profil bilgilerini içeren bir tuple (AppUserDto, AppUserProfileDto).</returns>
        Task<(AppUserDto user, AppUserProfileDto profile)> GetUserWithProfileAsync(string username);

        /// <summary>
        /// Kullanıcı raporu oluşturur; toplam müşteri sayısı, rezervasyon yapan ve yapmayan müşteri sayısı,
        /// ayrıca ilgili kullanıcı, profil ve rezervasyon detaylarını döndürür.
        /// </summary>
        /// <returns>Rapor verilerini içeren tuple.</returns>
        Task<(int TotalCustomers, int CustomersWithReservations, int CustomersWithoutReservations, List<AppUserDto> Members, List<AppUserProfileDto> Profiles, List<ReservationDto> Reservations)> GetCustomerReportDataAsync();

        /// <summary>
        /// Yeni bir kullanıcı oluşturur; DTO üzerinden alınan verilerle, Identity sistemi kullanılarak
        /// kullanıcı kaydı yapılır, rol ataması gerçekleştirilir ve kullanıcı profil bilgileri oluşturulur.
        /// </summary>
        /// <param name="userDto">Kullanıcı bilgilerini içeren AppUserDto.</param>
        /// <param name="password">Kullanıcının şifresi.</param>
        /// <param name="role">Atanacak rol (varsayılan "Member").</param>
        /// <returns>Oluşturulan kullanıcıya ait AppUserDto.</returns>
        Task<AppUserDto> CreateUserWithProfileAsync(AppUserDto userDto, string password, string role = "Member");

        /// <summary>
        /// Belirtilen kullanıcı ID'sine göre, kullanıcı bilgilerini, profil bilgilerini ve rollerini birleştirerek
        /// düzenleme için gerekli DTO'yu oluşturur.
        /// </summary>
        /// <param name="userId">Düzenlenecek kullanıcının ID'si.</param>
        /// <returns>Güncelleme için kullanılacak AppUserDto.</returns>
        Task<AppUserDto> GetUserEditDataAsync(int userId);

        /// <summary>
        /// Belirtilen kullanıcıyı, ilgili profil bilgileriyle birlikte pasif (soft-delete) duruma getirir.
        /// Kullanıcı pasif ise işlem iptal edilir ve Admin kendi hesabını silemez.
        /// </summary>
        /// <param name="userId">Pasif duruma getirilecek kullanıcının ID'si.</param>
        /// <param name="currentUserId">Şu anki oturum açmış kullanıcının ID'si (kendi hesabını silmemek için).</param>
        /// <returns>İşlemin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> DeactivateUserAsync(int userId, int currentUserId);

        /// <summary>
        /// Tüm kullanıcıları, ilgili profil ve rol bilgileriyle birlikte getirir ve verilen filtre parametrelerine göre filtreler.
        /// Bu metot sayesinde controller, kullanıcı detaylarını çekme ve filtreleme işlemlerini BLL üzerinden gerçekleştirebilir.
        /// </summary>
        /// <param name="search">Kullanıcı adı, soyadı, e-posta veya kullanıcı adı araması için filtre ifadesi.</param>
        /// <param name="role">Kullanıcının rolüne göre filtreleme yapmak için rol adı.</param>
        /// <param name="status">Kullanıcının durumuna göre (örneğin, "Aktif", "Pasif") filtreleme yapmak için durum ifadesi.</param>
        /// <returns>Filtrelenmiş ve detayları tamamlanmış AppUserDto listesini asenkron olarak döndürür.</returns>
        Task<List<AppUserDto>> GetUsersWithDetailsAsync(string search, string role, string status);
    }
}
