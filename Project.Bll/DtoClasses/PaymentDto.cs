using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Rezervasyon ödeme bilgilerini taşımak için kullanılan DTO.
    /// Hangi rezervasyon için ödeme yapıldığını ve ödeme detaylarını içerir.
    /// </summary>
    public class PaymentDto : BaseDto
    {
        public DateTime PaymentDate { get; set; } // Ödemenin yapıldığı tarih
        public decimal PaymentAmount { get; set; } // Ödenen toplam tutar
        public PaymentMethod PaymentMethod { get; set; } // Ödeme yöntemi (Kredi Kartı, Nakit, Banka Havalesi)
        public int ReservationId { get; set; } // Ödemeye bağlı rezervasyon ID'si
    }
}
