using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class ExtraService : BaseEntity
    {
        public string Name { get; set; } // Hizmetin adı (Örn: "Spa", "Oda Servisi", "Minibar Kullanımı")
        public string Description { get; set; } // Hizmetin açıklaması
        public decimal Price { get; set; } // Hizmetin fiyatı

        // Relational Properties
        public virtual ICollection<ReservationExtraService> ReservationExtraServices { get; set; }
    }
}
