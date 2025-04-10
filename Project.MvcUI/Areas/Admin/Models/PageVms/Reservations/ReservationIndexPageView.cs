using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;

namespace Project.MvcUI.Areas.Admin.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon listeleme sayfasında kullanılan ViewModel'dir.
    /// Hem filtreleme kriterlerini hem de listelenecek rezervasyonları içerir.
    /// </summary>
    public class ReservationIndexPageView
    {
        public ReservationIndexPageView()
        {
            // Listeyi null referans hatalarına karşı başlatıyoruz
            Reservations = new List<ReservationListRequestModel>();
        }

        /// <summary>
        /// Müşteri adı, soyadı veya e-posta adresine göre yapılan arama metni.
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Ödeme durumu filtresi.
        /// null: tümü, true: ödenmiş, false: ödeme bekliyor.
        /// </summary>
        public bool? IsPaid { get; set; }

        /// <summary>
        /// Rezervasyonun genel durumu (onaylı, bekliyor, iptal).
        /// </summary>
        public ReservationStatus? Status { get; set; }

        /// <summary>
        /// Ekranda listelenecek rezervasyonların tutulduğu koleksiyon.
        /// </summary>
        public List<ReservationListRequestModel> Reservations { get; set; }
    }
}
