using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Veritabanı yedekleme işlemlerine ait bilgileri taşıyan DTO sınıfıdır.
    /// Bu sınıf, UI'da yedekleme geçmişi, yedek dosyaları gibi işlemlerde kullanılır.
    /// </summary>
    public class DatabaseBackupLogDto : BaseDto
    {
        public string FilePath { get; set; }       // Fiziksel klasör ve dosya yolu
        public string FileName { get; set; }       // Yedek dosyasının adı
        public int AppUserId { get; set; }         // Yedeklemeyi yapan kullanıcı ID'si
        public string UserName { get; set; }       // AppUser.UserName (View için doğrudan)
    }
}
