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
    /// BaseManager üzerinden temel CRUD işlemleri sağlanır. 
    /// </summary>
    public class AppUserProfileManager : BaseManager<AppUserProfileDto, AppUserProfile>, IAppUserProfileManager
    {
        readonly IAppUserProfileRepository _repository;
        public AppUserProfileManager(IAppUserProfileRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Belirtilen AppUserId'ye sahip kullanıcının profil bilgilerini getirir.
        /// </summary>
        /// <param name="appUserId">Kullanıcının AppUser ID'si.</param>
        /// <returns>
        /// Eğer profil bulunursa ilgili AppUserProfileDto, aksi takdirde null döner.
        /// </returns>
        public async Task<AppUserProfileDto> GetByAppUserIdAsync(int appUserId)
        {
            // İlgili AppUserId'ye sahip profili çekiyoruz.
            AppUserProfile? profile = await _repository.Where(x => x.AppUserId == appUserId).FirstOrDefaultAsync();

            // Eğer profil bulunamazsa null döner.
            if (profile == null) return null;

            // Profili DTO'ya mapleyerek geri döneriz.
            return _mapper.Map<AppUserProfileDto>(profile);
        }
    }
}
