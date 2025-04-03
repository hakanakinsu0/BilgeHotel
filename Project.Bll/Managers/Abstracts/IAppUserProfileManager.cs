using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// AppUserProfile işlemlerine özel CRUD ve diğer operasyonları tanımlayan arayüzdür.
    /// Bu arayüz, genel IManager arayüzünü genişleterek, kullanıcı profil verilerine erişim ve yönetim işlevlerini içerir.
    /// </summary>
    public interface IAppUserProfileManager : IManager<AppUserProfileDto, AppUserProfile>
    {
        /// <summary>
        /// Belirtilen AppUserId'ye sahip kullanıcının profil bilgilerini asenkron olarak getirir.
        /// </summary>
        /// <param name="appUserId">Kullanıcının ID'si.</param>
        /// <returns>İlgili kullanıcının profil bilgilerini taşıyan AppUserProfileDto.</returns>
        Task<AppUserProfileDto> GetByAppUserIdAsync(int appUserId);
    }
}
