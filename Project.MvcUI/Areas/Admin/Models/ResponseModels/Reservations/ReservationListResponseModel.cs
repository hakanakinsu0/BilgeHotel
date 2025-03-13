using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels
{
    public class ReservationListResponseModel
    {
        public List<ReservationListRequestModel> Reservations { get; set; } = new List<ReservationListRequestModel>();
    }
}
