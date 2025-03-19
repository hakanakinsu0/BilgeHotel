using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// AppUserProfile ile ilgili iş mantığı işlemlerini yöneten manager sınıfı. 
    /// BaseManager üzerinden temel CRUD işlemleri sağlanır. // AppUserProfile işlemleri için manager.
    /// </summary>
    public class AppUserProfileManager : BaseManager<AppUserProfileDto, AppUserProfile>, IAppUserProfileManager
    {
        readonly IAppUserProfileRepository _repository;
        public AppUserProfileManager(IAppUserProfileRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Belirtilen AppUserId'ye sahip kullanıcının profilini getirir. // AppUserId'ye göre profil getirir.
        /// </summary>
        /// <param name="appUserId">Kullanıcının ID'si</param>
        /// <returns>AppUserProfileDto</returns>
        public async Task<AppUserProfileDto> GetByAppUserIdAsync(int appUserId)
        {
            AppUserProfile? profile = await _repository.Where(x => x.AppUserId == appUserId).FirstOrDefaultAsync(); // AppUserId'ye göre profili getir
            return _mapper.Map<AppUserProfileDto>(profile);  // DTO'ya map et ve döndür
        }
    }
}
