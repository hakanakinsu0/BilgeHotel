using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Otelde sunulan paket seçeneklerini temsil eder.
    /// Örnek: Tam Pansiyon, Her Şey Dahil.
    /// </summary>
    public class Package : BaseEntity
    {
        public string Name { get; set; } // Paket adı (ör. "Tam Pansiyon").
        public string Description { get; set; } // Paket açıklaması (ör. "Kahvaltı, öğle yemeği ve akşam yemeği dahildir").
        public decimal PriceMultiplier { get; set; } // Paket fiyat çarpanı.

        // Relational Properties
        public virtual ICollection<Reservation> Reservations { get; set; } // Bu paketle ilişkili rezervasyonlar.
    }
}
