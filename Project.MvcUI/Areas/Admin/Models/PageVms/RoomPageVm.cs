using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.RoomModels;

namespace Project.MvcUI.Areas.Admin.Models.PageVms
{
    public class RoomPageVm
    {
        public List<RoomResponseModel> Rooms { get; set; } = new();
        public int TotalRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
    }
}
