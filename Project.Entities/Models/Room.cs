using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Relational Properties
        public virtual RoomType RoomType { get; set; } // 1 RoomType N Room, 1 Room 1 RoomType
        public virtual ICollection<RoomFeature> RoomFeatures { get; set; } // Junction Table: 1 Room N Feature, 1 Feature N Room
        public virtual ICollection<Reservation> Reservations { get; set; } // 1 Room N Reservation, 1 Reservation 1 Room

    }
}
