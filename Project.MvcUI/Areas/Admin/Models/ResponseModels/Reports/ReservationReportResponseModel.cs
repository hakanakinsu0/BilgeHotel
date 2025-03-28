using System;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// UI'da gösterilmek üzere rezervasyon raporu detaylarını temsil eder.
    /// Müşteri adı, oda numarası, rezervasyon tarihleri, durum ve toplam ücret gibi bilgileri içerir.
    /// </summary>
    public class ReservationReportResponseModel
    {
        public int Id { get; set; } // Rezervasyonun benzersiz ID'si

        public string CustomerName { get; set; } // Rezervasyonu yapan müşterinin adı

        public string RoomNumber { get; set; } // Rezervasyonun yapıldığı oda numarası

        public DateTime StartDate { get; set; } // Rezervasyon başlangıç (giriş) tarihi

        public DateTime EndDate { get; set; } // Rezervasyon bitiş (çıkış) tarihi

        public string ReservationStatus { get; set; } // Rezervasyon durumu (örn. Confirmed, PendingPayment, Canceled)

        public decimal TotalPrice { get; set; } // Rezervasyonun toplam ücreti
    }
}
