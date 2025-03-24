using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class ReservationUpdateRequestModel
    {
        [Display(Name = "Rezervasyon ID'si")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        [Display(Name = "Başlangıç Tarihi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Bitiş Tarihi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Oda Seçimi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int RoomId { get; set; }

        [Display(Name = "Paket Seçimi (Opsiyonel)")]
        public int? PackageId { get; set; }

        [Display(Name = "Toplam Fiyat")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "Ekstra Hizmetler")]
        public List<int>? ExtraServiceIds { get; set; } // Güncellenmiş ekstra hizmetler
    }
}
