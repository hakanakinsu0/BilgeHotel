using Project.Entities.Enums;
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
        public DateTime PaymentDate { get; set; }            // Ödemenin yapıldığı tarih.
        public decimal PaymentAmount { get; set; }           // Ödenen toplam tutar.
        public PaymentMethod PaymentMethod { get; set; }     // Ödeme yöntemi (Kredi Kartı, Nakit, Banka Havalesi).

        // Foreign Keys
        public int ReservationId { get; set; }               // Ödemenin hangi rezervasyona ait olduğunu belirtir.

        // Relational Properties
        public virtual Reservation Reservation { get; set; } // 1 Reservation 1 Payment, 1 Payment 1 Reservation (Bir rezervasyonun bir ödemesi olabilir.)
    }
}
