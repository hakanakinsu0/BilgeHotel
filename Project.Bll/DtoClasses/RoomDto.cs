using Project.Entities.Enums;
using System;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Oteldeki odaların temel bilgilerini taşıyan DTO sınıfıdır.
    /// Bu sınıf, odanın numarası, bulunduğu kat, gecelik fiyatı, durum bilgileri ve özelliklerini içerir.
    /// </summary>
    public class RoomDto : BaseDto
    {
        public string RoomNumber { get; set; } // Odanın numarası
        public int Floor { get; set; } // Odanın bulunduğu kat
        public decimal PricePerNight { get; set; } // Odanın gecelik fiyatı
        public RoomStatus RoomStatus { get; set; } // Odanın durumu (Boş, Dolu, Bakımda)
        public int RoomTypeId { get; set; } // Oda türünün ID'si
        public string RoomTypeName { get; set; } // Oda türü adı
        public bool HasBalcony { get; set; } // Odanın balkonu var mı?
        public bool HasMinibar { get; set; } // Odanın minibarı var mı?
        public bool HasAirConditioner { get; set; } // Odanın klima sistemi var mı?
        public bool HasTV { get; set; } // Odanın televizyonu var mı?
        public bool HasHairDryer { get; set; } // Odanın saç kurutma makinesi var mı?
        public bool HasWifi { get; set; } // Odanın kablosuz internet erişimi var mı?
        public bool IsReserved { get; set; } // Oda şu an rezerve edilmiş mi?

        //Yeni eklendi
        public RoomStatus? FilterRoomStatus { get; set; } // Filtreleme için
        public decimal? MaxPrice { get; set; } // Filtreleme için
        public bool? FilterIsReserved { get; set; } // Filtreleme için

        //Filtreleme
        public int Page { get; set; } // sayfa numarası (Controller'dan gelecek)
        public int PageSize { get; set; } // sayfa boyutu
        public int TotalRooms { get; set; } // toplam kayıt sayısı (BLL dolduracak)

    }
}
