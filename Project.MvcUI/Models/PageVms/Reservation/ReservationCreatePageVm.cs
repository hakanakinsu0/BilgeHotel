using Microsoft.AspNetCore.Mvc.Rendering;
using Project.MvcUI.Models.PureVms.Reservations.RequestModels;
using System.Collections.Generic;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Yeni rezervasyon oluşturma sayfası için Page View Model.
    /// Bu model, form verileri ile birlikte seçilebilir liste verilerini ve UI'ya özgü diğer bilgileri içerir.
    /// </summary>
    public class ReservationCreatePageVm
    {
        public ReservationCreatePageVm()
        {
            PageTitle = "Yeni Rezervasyon Oluştur";
            HelpText = "Lütfen rezervasyon bilgilerinizi giriniz.";
            // Liste koleksiyonları boş listeler olarak başlatılabilir.
            RoomSelectList = new List<SelectListItem>();
            PackageSelectList = new List<SelectListItem>();
            ExtraServicesSelectList = new List<SelectListItem>();
            FloorsInfo = new Dictionary<int, string>();
        }

        /// <summary>
        /// Rezervasyon form verilerini taşır.
        /// </summary>
        public ReservationCreateRequestModel ReservationCreateRequest { get; set; }

        /// <summary>
        /// Oda seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> RoomSelectList { get; set; }

        /// <summary>
        /// Paket seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> PackageSelectList { get; set; }

        /// <summary>
        /// Ekstra hizmetler seçim listesi.
        /// </summary>
        public IEnumerable<SelectListItem> ExtraServicesSelectList { get; set; }

        /// <summary>
        /// Kat bilgilerini içeren dictionary (kat numarası - açıklama).
        /// </summary>
        public IDictionary<int, string> FloorsInfo { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Yardım metni.
        /// </summary>
        public string? HelpText { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Başarı mesajı.
        /// </summary>
        public string? SuccessMessage { get; set; }
    }
}
