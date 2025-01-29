using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Enums
{
    /// <summary>
    /// Odaların durumlarını temsil eder.
    /// </summary>
    public enum RoomStatus
    {
        Empty = 1, // Oda boş.
        Occupied = 2, // Oda dolu.
        Maintenance = 3 // Oda bakımda.
    }
}
