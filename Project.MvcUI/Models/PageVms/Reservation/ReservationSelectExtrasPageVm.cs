using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Project.MvcUI.Models.PureVms.Reservations.RequestModels;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyona ait ekstra hizmet seçimi sayfasında kullanılacak tüm bilgileri içerir.
    /// Hem form (ReservationSelectExtrasRequestModel) bilgisini hem de ekstra hizmet seçim listesi (SelectListItem) verilerini barındırır.
    /// </summary>
    public class ReservationSelectExtrasPageVm
    {
        /// <summary>
        /// Constructor: Form modeli ve ekstra hizmet listesi başlatılır.
        /// </summary>
        public ReservationSelectExtrasPageVm()
        {
            ReservationSelectExtrasRequest = new ReservationSelectExtrasRequestModel();
            ExtraServices = new List<SelectListItem>();
        }

        /// <summary>
        /// Kullanıcıdan ekstra hizmet seçimlerini almak için kullanılan form modeli.
        /// </summary>
        public ReservationSelectExtrasRequestModel ReservationSelectExtrasRequest { get; set; }

        /// <summary>
        /// Ekstra hizmet seçim listesi (SelectListItem formatında).
        /// </summary>
        public IEnumerable<SelectListItem> ExtraServices { get; set; }
    }
}
