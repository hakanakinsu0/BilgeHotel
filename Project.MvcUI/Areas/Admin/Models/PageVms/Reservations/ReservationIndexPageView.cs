using Project.Entities.Enums;
using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using Project.MvcUI.Areas.Admin.Models.ResponseModels;

namespace Project.MvcUI.Areas.Admin.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon listeleme sayfasında hem filtre parametrelerini,
    /// hem de listelenen rezervasyon verilerini tutan birleşik model.
    /// </summary>
    public class ReservationIndexPageView
    {
        public ReservationIndexPageView()
        {
            Reservations = new List<ReservationListRequestModel>();

        }
        public string Search { get; set; }   // Müşteri adı veya e-posta araması
        public bool? IsPaid { get; set; }    // Ödeme durumu (true: ödenmiş, false: bekliyor)
        public ReservationStatus? Status { get; set; }
        public List<ReservationListRequestModel> Reservations { get; set; }
        
    }

}
