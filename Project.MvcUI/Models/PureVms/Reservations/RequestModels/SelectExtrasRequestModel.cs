using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class SelectExtrasRequestModel
    {
        [Required(ErrorMessage = "Rezervasyon ID gereklidir.")]
        public int ReservationId { get; set; } // Hangi rezervasyona ekstra hizmet eklenecek

        // Kullanıcının seçtiği ekstra hizmetlerin ID listesi
        public List<int>? ExtraServiceIds { get; set; } = new List<int>();
    }
}
