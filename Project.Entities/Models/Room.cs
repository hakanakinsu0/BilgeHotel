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

        // Foreign Keys
        public int RoomTypeId { get; set; } // Odanın türü.

        // Relational Properties
        public virtual RoomType RoomType { get; set; } // Oda türü ile ilişki.
        public virtual ICollection<RoomFeature> RoomFeatures { get; set; } // Oda özellikleri ile ilişki.
        public virtual ICollection<Reservation> Reservations { get; set; } // Rezervasyonlarla ilişki.
    }
}
