using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    /// <summary>
    /// DatabaseBackupLog entity’sine ait veritabanı işlemlerini gerçekleştiren somut repository sınıfıdır.
    /// BaseRepository üzerinden CRUD işlemlerini devralır.
    /// </summary>
    public class DatabaseBackupLogRepository : BaseRepository<DatabaseBackupLog>, IDatabaseBackupLogRepository
    {
        /// <summary>
        /// `DatabaseBackupLogRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public DatabaseBackupLogRepository(MyContext context) : base(context)
        {
        }
    }
}
