using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class ReservationSelectExtrasRequestModel
    {
        [Display(Name = "Rezervasyon ID'si")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        [Display(Name = "Ekstra Hizmetler (Opsiyonel)")]
        public List<int>? ExtraServiceIds { get; set; } = new List<int>();
    }
}
