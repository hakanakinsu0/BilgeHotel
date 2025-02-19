namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.RoomModels
{
    public class RoomAvailabilityResponseModel
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public bool IsOccupied { get; set; } // Oda dolu mu?
        public DateTime? NextAvailableDate { get; set; } // Boşalacağı tarih (eğer doluysa)
    }
}
