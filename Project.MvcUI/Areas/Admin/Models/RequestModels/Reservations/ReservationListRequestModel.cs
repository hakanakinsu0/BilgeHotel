using System;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationListRequestModel
    {
        public int Id { get; set; } // Rezervasyon ID
        public string CustomerName { get; set; } // Müşteri Adı ve Soyadı
        public string CustomerEmail { get; set; } // Müşteri E-Postası
        public string RoomNumber { get; set; } // Oda Numarası
        public DateTime StartDate { get; set; } // Giriş Tarihi
        public DateTime EndDate { get; set; } // Çıkış Tarihi
        public decimal TotalPrice { get; set; } // Toplam Fiyat
        public bool IsPaid { get; set; } // Ödeme Durumu (True: Ödendi, False: Bekleniyor)
        public string ReservationStatus { get; set; } // Rezervasyon Durumu ("Tamamlandı", "Bekleniyor", "İptal Edildi")
        public List<string> ExtraServices { get; set; } // ✅ Ekstra hizmetler eklendi
    }
}
