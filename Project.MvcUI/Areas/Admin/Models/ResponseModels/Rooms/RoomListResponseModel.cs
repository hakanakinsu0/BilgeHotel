using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Rooms
{
    public class RoomListResponseModel
    {
        public List<RoomListItemResponseModel> Rooms { get; set; } = new List<RoomListItemResponseModel>(); // Oda listesi

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
