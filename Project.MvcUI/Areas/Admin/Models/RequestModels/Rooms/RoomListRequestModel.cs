namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomListRequestModel
    {
        public int? RoomTypeId { get; set; } // Oda Türü ID
        public string Status { get; set; } // Oda Durumu (Empty, Occupied, Maintenance)
        public int? Floor { get; set; } // Kat Bilgisi
        public decimal? MinPrice { get; set; } // Minimum Fiyat
        public decimal? MaxPrice { get; set; } // Maksimum Fiyat
        public bool? HasReservation { get; set; } // Rezerve edilmiş mi?
    }
}
