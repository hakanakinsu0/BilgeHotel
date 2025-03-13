using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Enums
{
    /// <summary>
    /// Rezervasyonun mevcut durumunu temsil eder.
    /// </summary>
    public enum ReservationStatus
    {
        PendingPayment = 1, // Ödeme bekleniyor
        Confirmed = 2,      // Ödeme yapıldı, rezervasyon onaylandı
        Canceled = 3        // Rezervasyon iptal edildi
    }
}
