using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class ReservationUpdateRequestModel
    {
        [Required]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi gereklidir.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi gereklidir.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Oda seçilmelidir.")]
        public int RoomId { get; set; }

        public int? PackageId { get; set; }

        public decimal TotalPrice { get; set; }

        public List<int> ExtraServiceIds { get; set; } = new List<int>(); // Güncellenmiş ekstra hizmetler
    }
}
