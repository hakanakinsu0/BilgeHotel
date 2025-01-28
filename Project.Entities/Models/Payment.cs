using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Rezervasyon ödemelerini temsil eder.
    /// Hangi rezervasyon için ödeme yapıldığını ve ödeme detaylarını içerir.
    /// </summary>
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; } // Ödemenin yapıldığı tarih.
        public decimal PaymentAmount { get; set; } // Ödenen toplam tutar.
        public string PaymentMethod { get; set; } // Ödeme yöntemi (ör. "Kredi Kartı").

        // Foreign Keys
        public int ReservationId { get; set; } // Ödemeye bağlı rezervasyon.

        // Relational Properties
        public virtual Reservation Reservation { get; set; } // Rezervasyon ile ilişki.

    }
}
