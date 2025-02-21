using Project.Entities.Enums;
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
        public int? AppUserId { get; set; } // Rezervasyonu yapan müşteri.
        public int RoomId { get; set; } // Rezerve edilen oda.
        public int? PackageId { get; set; } // Rezervasyon için seçilen paket.
        public int? EmployeeId { get; set; } // Rezervasyonu yöneten Employee (Opsiyonel)
        public ReservationStatus ReservationStatus { get; set; }


        // Relational Properties
        public virtual AppUser Reservations { get; set; }
        public virtual Room Room { get; set; } // 1 Room N Reservation, 1 Reservation 1 Room
        public virtual Package Package { get; set; } // 1 Package N Reservation, 1 Reservation 1 Package
        public virtual Payment Payment { get; set; } // 1 Reservation 1 Payment, 1 Payment 1 Reservation
        public virtual Employee Employee { get; set; } // 1 Employee N Reservation, 1 Reservation 1 Employee
        public virtual ICollection<ReservationExtraService> ReservationExtraServices { get; set; }

    }
}
