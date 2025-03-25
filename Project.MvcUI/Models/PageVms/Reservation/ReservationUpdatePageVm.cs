using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Project.MvcUI.Models.PureVms.Reservations.RequestModels;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon güncelleme sayfasında kullanılacak tüm bilgileri içerir.
    /// Form modeli (ReservationUpdateRequestModel) ile birlikte, oda, paket ve ekstra hizmet seçim listelerini barındırır.
    /// </summary>
    public class ReservationUpdatePageVm
    {
        /// <summary>
        /// Rezervasyon güncelleme form modelidir.
        /// </summary>
        public ReservationUpdateRequestModel ReservationUpdateRequest { get; set; } = new ReservationUpdateRequestModel();

        /// <summary>
        /// Oda seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> Rooms { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// Paket seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> Packages { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// Ekstra hizmet seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> ExtraServices { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; } = "Rezervasyon Güncelleme";

        /// <summary>
        /// Kullanıcıya gösterilecek yardımcı metin.
        /// </summary>
        public string HelpText { get; set; } = "Rezervasyon bilgilerinizi güncellemek için aşağıdaki alanları düzenleyin.";
    }
}
