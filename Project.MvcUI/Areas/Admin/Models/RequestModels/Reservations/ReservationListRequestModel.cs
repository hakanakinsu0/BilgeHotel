using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationListRequestModel
    {
        [Display(Name = "Rezervasyon ID")]
        public int Id { get; set; } // Rezervasyon ID

        [Display(Name = "Müşteri Adı ve Soyadı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CustomerName { get; set; } // Müşteri Adı ve Soyadı

        [Display(Name = "Müşteri E-Postası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [EmailAddress(ErrorMessage = "{0} geçerli bir e-posta adresi olmalıdır.")]
        public string CustomerEmail { get; set; } // Müşteri E-Postası

        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string RoomNumber { get; set; } // Oda Numarası

        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } // Giriş Tarihi

        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } // Çıkış Tarihi

        [Display(Name = "Toplam Fiyat")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; } // Toplam Fiyat

        [Display(Name = "Ödeme Durumu")]
        public bool IsPaid { get; set; } // Ödeme Durumu (True: Ödendi, False: Bekleniyor)

        [Display(Name = "Rezervasyon Durumu")]
        public string ReservationStatus { get; set; } // Rezervasyon Durumu ("Tamamlandı", "Bekleniyor", "İptal Edildi")

        [Display(Name = "Ekstra Hizmetler")]
        public List<string> ExtraServices { get; set; } // Ekstra hizmetler
    }
}
