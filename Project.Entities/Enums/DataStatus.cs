using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Enums
{
    // DataStatus: Verinin durumunu belirlemek için kullanılan enumdur.
    // Amaç: Verilerin eklenme, güncellenme ve silinme durumlarını izlemek.
    public enum DataStatus
    {
        Inserted = 1, // Verinin yeni eklendiği durum.
        Updated = 2,  // Verinin güncellendiği durum.
        Deleted = 3   // Verinin silindiği durum.
    }
}
