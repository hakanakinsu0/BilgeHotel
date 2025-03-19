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
    /// AppUserProfile için ortak CRUD işlemlerini içeren IManager arayüzünü genişleten arayüz. AppUserProfile işlemleri için arayüz
    /// </summary>
    public interface IAppUserProfileManager : IManager<AppUserProfileDto, AppUserProfile> 
    {
        /// <summary>
        /// Belirtilen AppUserId'ye sahip kullanıcının profilini getirir. // AppUserId'ye göre profil getirir
        /// </summary>
        /// <param name="appUserId">Kullanıcının ID'si</param>
        /// <returns>AppUserProfileDto</returns>
        Task<AppUserProfileDto> GetByAppUserIdAsync(int appUserId); // AppUserId'ye göre profil getir
    }
}
