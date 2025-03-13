namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Rooms
{
    public class RoomListItemResponseModel
    {
        public int Id { get; set; } // Oda ID
        public string RoomNumber { get; set; } // Oda Numarası
        public string RoomType { get; set; } // Oda Türü Adı
        public int Floor { get; set; } // Kat Bilgisi
        public decimal PricePerNight { get; set; } // Gecelik Ücret
        public string RoomStatus { get; set; } // Oda Durumu (Empty, Occupied, Maintenance)
        public bool IsReserved { get; set; } // Oda şu an rezerve edilmiş mi?

        // **Yeni Eklenen Alanlar**
        public bool HasBalcony { get; set; } // Balkon var mı?
        public bool HasMinibar { get; set; } // Minibar var mı?
        public bool HasAirConditioner { get; set; } // Klima var mı?
        public bool HasTV { get; set; } // TV var mı?
        public bool HasHairDryer { get; set; } // Saç Kurutma Makinesi var mı?
        public bool HasWifi { get; set; } // WiFi var mı?
    }
}
