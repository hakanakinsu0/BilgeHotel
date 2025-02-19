namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.RoomModels
{
    public class RoomResponseModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
    }
}
