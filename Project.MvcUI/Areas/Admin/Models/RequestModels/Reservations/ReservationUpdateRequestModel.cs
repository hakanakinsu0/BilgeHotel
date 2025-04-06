using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationUpdateRequestModel
    {
        [Display(Name = "Rezervasyon ID")]
        public int ReservationId { get; set; }

        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        public string CustomerName { get; set; }

        [Display(Name = "Müşteri E-Postası")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        [EmailAddress(ErrorMessage = "{0} geçerli bir e-posta adresi olmalıdır.")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Oda")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public int RoomId { get; set; }

        [Display(Name = "Giriş Tarihi")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Çıkış Tarihi")]
        [Required(ErrorMessage = "{0} boş olamaz.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Paket")]
        public int? PackageId { get; set; }

        [Display(Name = "Ekstra Hizmetler")]
        public List<int> ExtraServiceIds { get; set; } = new List<int>();

        [Display(Name = "Rezervasyon Durumu")]
        public ReservationStatus ReservationStatus { get; set; }

        [Display(Name = "Rezervasyonu tekrar aktif yap")]
        public bool ReactivateReservation { get; set; }
    }
}
