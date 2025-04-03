using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    /// <summary>
    /// Kullanıcının yeni bir rezervasyon oluşturmak için doldurduğu form verilerini temsil eder.
    /// Giriş/çıkış tarihleri, oda, paket ve isteğe bağlı ekstra hizmetler içerir.
    /// </summary>
    public class ReservationCreateRequestModel
    {
        /// <summary>
        /// Rezervasyonun başlangıç (giriş) tarihi.
        /// </summary>
        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Rezervasyonun bitiş (çıkış) tarihi.
        /// </summary>
        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Seçilen oda ID'si.
        /// </summary>
        [Display(Name = "Oda Seçimi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int? RoomId { get; set; }

        /// <summary>
        /// Seçilen konaklama paketi ID'si.
        /// </summary>
        [Display(Name = "Paket Seçimi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int? PackageId { get; set; }

        /// <summary>
        /// Seçilen ekstra hizmet ID'leri. Bu alan opsiyoneldir.
        /// </summary>
        [Display(Name = "Ekstra Hizmetler (Opsiyonel)")]
        public List<int>? ExtraServiceIds { get; set; }
    }
}
