using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    /// <summary>
    /// Kullanıcının rezervasyon güncelleme işlemi için gönderdiği form verilerini temsil eder.
    /// Tarih, oda, paket ve ekstra hizmet bilgilerini içerir.
    /// </summary>
    public class ReservationUpdateRequestModel
    {
        /// <summary>
        /// Güncellenecek rezervasyonun ID'si.
        /// </summary>
        [Display(Name = "Rezervasyon ID'si")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        /// <summary>
        /// Yeni giriş (başlangıç) tarihi.
        /// </summary>
        [Display(Name = "Başlangıç Tarihi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Yeni çıkış (bitiş) tarihi.
        /// </summary>
        [Display(Name = "Bitiş Tarihi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Seçilen yeni oda ID'si.
        /// </summary>
        [Display(Name = "Oda Seçimi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int RoomId { get; set; }

        /// <summary>
        /// Seçilen yeni paket ID'si. Opsiyoneldir.
        /// </summary>
        [Display(Name = "Paket Seçimi (Opsiyonel)")]
        public int? PackageId { get; set; }

        /// <summary>
        /// Güncellenmiş toplam fiyat.
        /// </summary>
        [Display(Name = "Toplam Fiyat")]
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Seçilen ekstra hizmetlerin ID listesi.
        /// </summary>
        [Display(Name = "Ekstra Hizmetler")]
        public List<int>? ExtraServiceIds { get; set; }
    }
}
