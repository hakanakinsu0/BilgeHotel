using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Enums
{
    /// <summary>
    /// Verinin durumunu belirlemek için kullanılan enumdur.
    /// Bu enum ile verilerin eklenme, güncellenme ve pasif hale getirilme durumlarını izleriz.
    /// </summary>
    public enum DataStatus
    {
        Inserted = 1, // Yeni eklenen veri. Varsayılan başlangıç durumu.
        Updated = 2,  // Güncellenmiş veri.
        Deleted = 3   // Pasif hale getirilmiş veri (Soft delete). Veritabanında fiziksel olarak silinmez.
    }
}
