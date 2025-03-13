using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationUpdateRequestModel
    {
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Müşteri adı boş olamaz.")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "E-posta adresi boş olamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string CustomerEmail { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int? PackageId { get; set; }

        // ✅ Ekstra Hizmetler İçin Liste Eklendi
        public List<int> ExtraServiceIds { get; set; } = new List<int>();

        public ReservationStatus ReservationStatus { get; set; }
    }
}
