using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Oteldeki oda türlerini temsil eder.
    /// Örnek: Tek kişilik, çift kişilik, kral dairesi gibi.
    /// </summary>
    public class RoomType : BaseEntity
    {
        public string Name { get; set; } // Oda türünün adı (ör. "Tek Kişilik").
        public string Description { get; set; } // Oda türünün açıklaması (opsiyonel).

        // Relational Properties
        public virtual ICollection<Room> Rooms { get; set; } // 1 RoomType N Room, 1 Room 1 RoomType

    }
}
