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
    /// Veritabanı yedekleme işlemlerini yöneten manager interface'idir.
    /// Yedekleme kayıtlarının eklenmesi, listelenmesi ve silinmesi gibi işlemleri tanımlar.
    /// </summary>
    public interface IDatabaseBackupLogManager : IManager<DatabaseBackupLogDto, DatabaseBackupLog>
    {
        /// <summary>
        /// Belirli bir kullanıcının (AppUser) yedekleme geçmişini getirir.
        /// </summary>
        Task<List<DatabaseBackupLogDto>> GetBackupsByUserAsync(int userId);

        /// <summary>
        /// Tüm yedeklemeleri tarihe göre sıralı şekilde getirir.
        /// </summary>
        Task<List<DatabaseBackupLogDto>> GetAllBackupsOrderedAsync();
    }
}
