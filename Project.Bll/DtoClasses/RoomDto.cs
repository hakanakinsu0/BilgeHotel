using Project.Entities.Enums;
using System;

namespace Project.Bll.DtoClasses
{
    public class RoomDto : BaseDto
    {
        public string RoomNumber { get; set; } // Odanın numarası
        public int Floor { get; set; } // Odanın bulunduğu kat
        public decimal PricePerNight { get; set; } // Odanın gecelik fiyatı
        public RoomStatus RoomStatus { get; set; } // Odanın durumu (Boş, Dolu, Bakımda)
        public int RoomTypeId { get; set; } // Oda türünün ID'si
        public string RoomTypeName { get; set; } // Oda türü adı

        // **Yeni Eklenen Alanlar**
        public bool HasBalcony { get; set; }
        public bool HasMinibar { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasTV { get; set; }
        public bool HasHairDryer { get; set; }
        public bool HasWifi { get; set; }
    }
}
