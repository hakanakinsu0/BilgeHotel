using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    /// <summary>
    /// Kullanıcının rezervasyona ekstra hizmet eklemek için gönderdiği form verilerini temsil eder.
    /// </summary>
    public class ReservationSelectExtrasRequestModel
    {
        /// <summary>
        /// Ekstra hizmetlerin ekleneceği rezervasyonun ID'si.
        /// </summary>
        [Display(Name = "Rezervasyon ID'si")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        /// <summary>
        /// Seçilen ekstra hizmetlerin ID listesi. Opsiyonel bir alandır.
        /// </summary>
        [Display(Name = "Ekstra Hizmetler (Opsiyonel)")]
        public List<int>? ExtraServiceIds { get; set; }
    }
}
