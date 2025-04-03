using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class ReservationCreateRequestModel
    {
        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Oda Seçimi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int? RoomId { get; set; }

        [Display(Name = "Paket Seçimi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int? PackageId { get; set; }

        [Display(Name = "Ekstra Hizmetler (Opsiyonel)")]
        public List<int>? ExtraServiceIds { get; set; } = new List<int>();
    }
}
