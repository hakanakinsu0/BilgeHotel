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
    /// Veritabanı yedekleme işlemlerinin iş mantığını yöneten manager sınıfıdır.
    /// Yedek kayıtlarının eklenmesi, silinmesi, kullanıcıya göre listelenmesi gibi işlemleri gerçekleştirir.
    /// </summary>
    public class DatabaseBackupLogManager : BaseManager<DatabaseBackupLogDto, DatabaseBackupLog>, IDatabaseBackupLogManager
    {
        private readonly IDatabaseBackupLogRepository _repository;

        public DatabaseBackupLogManager(IDatabaseBackupLogRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Belirli bir kullanıcıya ait yedeklemeleri getirir.
        /// </summary>
        public async Task<List<DatabaseBackupLogDto>> GetBackupsByUserAsync(int userId)
        {
            List<DatabaseBackupLog> entities = await _repository.Where(x => x.AppUserId == userId).ToListAsync();
            return _mapper.Map<List<DatabaseBackupLogDto>>(entities);
        }

        /// <summary>
        /// Tüm yedekleme loglarını tarihe göre azalan sırayla getirir.
        /// </summary>
        public async Task<List<DatabaseBackupLogDto>> GetAllBackupsOrderedAsync()
        {
            List<DatabaseBackupLog> entities = await _repository.GetAllAsync();
            List<DatabaseBackupLog> orderedEntities = entities.OrderByDescending(x => x.CreatedDate).ToList();
            return _mapper.Map<List<DatabaseBackupLogDto>>(orderedEntities);
        }
    }
}