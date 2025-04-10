using System;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    /// <summary>
    /// Rezervasyon listeleme ekranında kullanılan filtreleme parametrelerini taşıyan modeldir.
    /// Müşteri arama metni, oda ID’si, rezervasyon durumu ve ödeme bilgisine göre filtreleme yapılmasını sağlar.
    /// </summary>
    public class ReservationIndexRequestModel
    {
        /// <summary>Müşteri adı veya e-posta ile arama yapmak için kullanılan metin.</summary>
        public string Search { get; set; }

        /// <summary>Filtreleme için seçilen oda ID'si (nullable).</summary>
        public int? RoomId { get; set; }

        /// <summary>Rezervasyonun durumunu temsil eder (örn. Confirmed, Canceled vb.).</summary>
        public string Status { get; set; }

        /// <summary>Ödemenin yapılıp yapılmadığını gösteren filtre (true: ödendi, false: bekliyor, null: tümü).</summary>
        public bool? IsPaid { get; set; }
    }
}
