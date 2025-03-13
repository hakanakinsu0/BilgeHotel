using Project.Entities.Enums;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomDeleteRequestModel
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }
        public string RoomTypeName { get; set; }
        public RoomStatus RoomStatus { get; set; }
        public bool HasActiveReservations { get; set; } // Eğer aktif rezervasyon varsa, silinemez.
    }
}
