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
        /// Constructor: Form modeli ve seçim listeleri varsayılan olarak başlatılır.
        /// </summary>
        public ReservationUpdatePageVm()
        {
            ReservationUpdateRequest = new ReservationUpdateRequestModel();
            Rooms = new List<SelectListItem>();
            Packages = new List<SelectListItem>();
            ExtraServices = new List<SelectListItem>();
            PageTitle = "Rezervasyon Güncelleme";
            HelpText = "Rezervasyon bilgilerinizi güncellemek için aşağıdaki alanları düzenleyin.";
        }

        /// <summary>
        /// Rezervasyon güncelleme form modelidir.
        /// </summary>
        public ReservationUpdateRequestModel ReservationUpdateRequest { get; set; }

        /// <summary>
        /// Oda seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> Rooms { get; set; }

        /// <summary>
        /// Paket seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> Packages { get; set; }

        /// <summary>
        /// Ekstra hizmet seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> ExtraServices { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Kullanıcıya gösterilecek yardımcı metin.
        /// </summary>
        public string HelpText { get; set; }
    }
}
