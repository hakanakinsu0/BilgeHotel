using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Enums
{
    /// <summary>
    /// Verinin durumunu belirlemek için kullanılan enumdur.
    /// Verilerin eklenme, güncellenme ve silinme durumlarını izlemek.
    /// </summary>
    public enum DataStatus
    {
        Inserted = 1, // Verinin yeni eklendiği durum.
        Updated = 2,  // Verinin güncellendiği durum.
        Deleted = 3   // Verinin silindiği durum.
    }
}
