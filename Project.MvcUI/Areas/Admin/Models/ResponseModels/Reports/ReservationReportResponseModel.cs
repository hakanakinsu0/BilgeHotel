using System;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    public class ReservationReportResponseModel
    {
        public int Id { get; set; } // Rezervasyon ID
        public string CustomerName { get; set; } // Müşteri Adı
        public string RoomNumber { get; set; } // Oda Numarası
        public DateTime StartDate { get; set; } // Giriş Tarihi
        public DateTime EndDate { get; set; } // Çıkış Tarihi
        public string ReservationStatus { get; set; } // Durum (Confirmed, PendingPayment, Canceled)
        public decimal TotalPrice { get; set; } // Toplam Ücret
    }
}
