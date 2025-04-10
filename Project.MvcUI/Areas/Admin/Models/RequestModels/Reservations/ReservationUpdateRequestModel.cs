using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    /// <summary>
    /// Rezervasyon düzenleme ekranında kullanılan veri modelidir.
    /// Formdan gelen verileri taşır ve doğrulama kurallarını içerir.
    /// </summary>
    public class ReservationUpdateRequestModel
    {
        /// <summary>Rezervasyonun eşsiz ID'si.</summary>
        [Display(Name = "Rezervasyon ID")]
        public int ReservationId { get; set; }

        /// <summary>Müşteri adı (readonly olabilir).</summary>
        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        public string CustomerName { get; set; }

        /// <summary>Müşteri e-posta adresi (readonly olabilir).</summary>
        [Display(Name = "Müşteri E-Postası")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        [EmailAddress(ErrorMessage = "{0} geçerli bir e-posta adresi olmalıdır.")]
        public string CustomerEmail { get; set; }

        /// <summary>Rezervasyonun yapıldığı oda ID'si.</summary>
        [Display(Name = "Oda")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public int RoomId { get; set; }

        /// <summary>Rezervasyonun başlangıç tarihi.</summary>
        [Display(Name = "Giriş Tarihi")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        /// <summary>Rezervasyonun bitiş tarihi.</summary>
        [Display(Name = "Çıkış Tarihi")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        /// <summary>Seçilen paket ID'si (nullable).</summary>
        [Display(Name = "Paket")]
        public int? PackageId { get; set; }

        /// <summary>Seçilen ekstra hizmetlerin ID listesi.</summary>
        [Display(Name = "Ekstra Hizmetler")]
        public List<int> ExtraServiceIds { get; set; } 

        /// <summary>Rezervasyonun mevcut durumu.</summary>
        [Display(Name = "Rezervasyon Durumu")]
        public ReservationStatus ReservationStatus { get; set; }

        /// <summary>Rezervasyon iptalse, tekrar aktif edilsin mi?</summary>
        [Display(Name = "Rezervasyonu tekrar aktif yap")]
        public bool ReactivateReservation { get; set; }
    }
}
