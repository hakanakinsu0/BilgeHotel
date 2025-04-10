using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    /// <summary>
    /// Rezervasyon listeleme işlemleri için kullanılan modeldir.
    /// Müşteri, oda, ödeme ve tarih bilgileri ile ekstra hizmetleri içerir.
    /// </summary>
    public class ReservationListRequestModel
    {
        /// <summary>Rezervasyona ait benzersiz ID.</summary>
        [Display(Name = "Rezervasyon ID")]
        public int Id { get; set; }

        /// <summary>Müşterinin adı ve soyadı.</summary>
        [Display(Name = "Müşteri Adı ve Soyadı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CustomerName { get; set; }

        /// <summary>Müşterinin e-posta adresi.</summary>
        [Display(Name = "Müşteri E-Postası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [EmailAddress(ErrorMessage = "{0} geçerli bir e-posta adresi olmalıdır.")]
        public string CustomerEmail { get; set; }

        /// <summary>Rezervasyon yapılan oda numarası.</summary>
        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string RoomNumber { get; set; }

        /// <summary>Rezervasyon başlangıç (giriş) tarihi.</summary>
        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>Rezervasyon bitiş (çıkış) tarihi.</summary>
        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        /// <summary>Toplam ücret bilgisi.</summary>
        [Display(Name = "Toplam Fiyat")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        /// <summary>Ödemenin yapılıp yapılmadığını gösteren bilgi.</summary>
        [Display(Name = "Ödeme Durumu")]
        public bool IsPaid { get; set; }

        /// <summary>Rezervasyonun genel durumu (Onaylandı, İptal Edildi vs.).</summary>
        [Display(Name = "Rezervasyon Durumu")]
        public string ReservationStatus { get; set; }

        /// <summary>Seçilen ekstra hizmetlerin listesi.</summary>
        [Display(Name = "Ekstra Hizmetler")]
        public List<string> ExtraServices { get; set; }
    }
}
