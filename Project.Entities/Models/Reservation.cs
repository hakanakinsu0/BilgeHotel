using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Otel rezervasyonlarını temsil eder.
    /// Müşteri, oda, paket ve ödeme bilgileri ile ilişkilidir.
    /// </summary>
    public class Reservation : BaseEntity
    {
        public DateTime StartDate { get; set; } // Rezervasyon başlangıç tarihi.
        public DateTime EndDate { get; set; } // Rezervasyon bitiş tarihi.
        public decimal TotalPrice { get; set; } // Rezervasyon toplam tutarı.

        //Foreign Keys
        public int CustomerId { get; set; } // Rezervasyonu yapan müşteri.
        public int RoomId { get; set; } // Rezerve edilen oda.
        public int PackageId { get; set; } // Rezervasyon için seçilen paket.


        // Relational Properties
        public virtual Customer Customer { get; set; } // Müşteri ile ilişki.
        public virtual Room Room { get; set; } // Oda ile ilişki.
        public virtual Package Package { get; set; } // Paket ile ilişki.
        public virtual Payment Payment { get; set; } // Ödeme ile ilişki (opsiyonel).
    }
}
