using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class ReservationCreateRequestModel
    {
        [Required(ErrorMessage = "Başlangıç tarihi gereklidir.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi gereklidir.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Oda seçimi gereklidir.")]
        public int RoomId { get; set; }

        // Opsiyonel: Paket seçimi
        public int? PackageId { get; set; }

        // Opsiyonel: Ek hizmetler için ID listesi
        public List<int>? ExtraServiceIds { get; set; } = new List<int>();
    }
}