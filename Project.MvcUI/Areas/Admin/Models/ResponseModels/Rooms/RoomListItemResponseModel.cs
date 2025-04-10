namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Rooms
{
    /// <summary>
    /// UI tarafında oda listeleme ekranında her bir satır için kullanılan modeldir.
    /// Odaya ait temel bilgileri ve donanım özelliklerini içerir.
    /// </summary>
    public class RoomListItemResponseModel
    {
        public int Id { get; set; } // Odanın benzersiz ID'si
        public string RoomNumber { get; set; } // Oda numarası
        public string RoomType { get; set; } // Odanın ait olduğu oda türü adı
        public int Floor { get; set; } // Odanın bulunduğu kat bilgisi
        public decimal PricePerNight { get; set; } // Odanın gecelik fiyatı
        public string RoomStatus { get; set; } // Odanın durumu (Empty, Occupied, Maintenance)
        public bool IsReserved { get; set; } // Oda şu an rezerve edilmiş mi?
        public bool HasBalcony { get; set; } // Balkon var mı?
        public bool HasMinibar { get; set; } // Minibar var mı?
        public bool HasAirConditioner { get; set; } // Klima var mı?
        public bool HasTV { get; set; } // TV var mı?
        public bool HasHairDryer { get; set; } // Saç kurutma makinesi var mı?
        public bool HasWifi { get; set; } // WiFi var mı?
    }
}
