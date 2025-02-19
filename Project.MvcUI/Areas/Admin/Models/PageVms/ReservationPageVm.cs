using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.ReservationModels;

namespace Project.MvcUI.Areas.Admin.Models.PageVms
{
    public class ReservationPageVm
    {
        public List<ReservationResponseModel> Reservations { get; set; } = new();
        public int TotalReservations { get; set; }
        public int ActiveReservations { get; set; }
        public int CancelledReservations { get; set; }
    }
}
