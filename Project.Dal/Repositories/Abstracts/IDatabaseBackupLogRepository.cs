using Project.Dal.Repositories.Concretes;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// DatabaseBackupLog entity’si için veri erişim işlemlerini tanımlayan repository interface'i.
    /// Bu interface, veritabanı yedekleme loglarının eklenmesi, silinmesi, güncellenmesi ve listelenmesi gibi işlemleri soyutlar.
    /// Temel CRUD işlemleri BaseRepository üzerinden devralınır.
    /// </summary>
    public interface IDatabaseBackupLogRepository : IRepository<DatabaseBackupLog>
    {
    }
}
