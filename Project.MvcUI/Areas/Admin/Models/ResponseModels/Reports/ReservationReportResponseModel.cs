using System;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Rezervasyon raporlarında görüntülenecek detaylı bilgileri temsil eder.
    /// Müşteri bilgisi, oda numarası, tarih aralığı, durum ve ücret bilgilerini içerir.
    /// </summary>
    public class ReservationReportResponseModel
    {
        public int Id { get; set; } // Rezervasyon ID'si
        public string CustomerName { get; set; } // Müşteri adı
        public string RoomNumber { get; set; } // Oda numarası
        public DateTime StartDate { get; set; } // Giriş tarihi
        public DateTime EndDate { get; set; } // Çıkış tarihi
        public string ReservationStatus { get; set; } // Rezervasyon durumu (Confirmed, PendingPayment, vb.)
        public decimal TotalPrice { get; set; } // Toplam ücret
    }
}
