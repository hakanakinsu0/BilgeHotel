using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Veritabanı yedekleme işlemlerinin loglarını tutar.
    /// Her yedekleme bir kayıt oluşturur.
    /// </summary>
    public class DatabaseBackupLog : BaseEntity
    {
        public string FilePath { get; set; }        // Fiziksel dosya yolu
        public string FileName { get; set; }        // Dosya adı (örn. bilgehotel_2025_04_14_2130.bak)

        // Foreign Keys
        public int AppUserId { get; set; }

        // Relational Properties
        public virtual AppUser AppUser { get; set; }    // 1 AppUser N DatabaseBackupLog, 1 DatabaseBackupLog 1 AppUser
    }
}
