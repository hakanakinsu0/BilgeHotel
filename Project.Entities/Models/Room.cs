using Project.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Project.Entities.Models
{
    /// <summary>
    /// Oteldeki odaları temsil eder.
    /// Oda türü, fiyat, kat bilgisi ve ilişkili özelliklerle bağlantılıdır.
    /// </summary>
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; } // Odanın numarası.
        public int Floor { get; set; } // Odanın bulunduğu kat.
        public decimal PricePerNight { get; set; } // Odanın gecelik fiyatı.
        public RoomStatus RoomStatus { get; set; } // Odanın durumu (Boş, Dolu, Bakımda).

        // Foreign Keys
        public int RoomTypeId { get; set; } // Odanın türü.

        // Odaların özellikleri
        public bool HasBalcony { get; set; } // 3. ve 4. kat odalarında var
        public bool HasMinibar { get; set; } // Tek kişilik odalar hariç tüm odalarda var
        public bool HasAirConditioner { get; set; } // Tüm odalarda var
        public bool HasTV { get; set; } // Tüm odalarda var
        public bool HasHairDryer { get; set; } // Tüm odalarda var
        public bool HasWifi { get; set; } // Tüm odalarda var

        // Relational Properties
        public virtual RoomType RoomType { get; set; } // 1 RoomType N Room, 1 Room 1 RoomType
        public virtual ICollection<Reservation> Reservations { get; set; } // 1 Room N Reservation, 1 Reservation 1 Room
    }
}
