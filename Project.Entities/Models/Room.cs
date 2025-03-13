using Project.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Project.Entities.Models
{
    /// <summary>
    /// Oteldeki odaları temsil eder.
    /// Oda türü, fiyat, kat bilgisi, özellikleri ve ilişkili özelliklerle bağlantılıdır.
    /// </summary>
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; }      // Odanın numarası.
        public int Floor { get; set; }              // Odanın bulunduğu kat.
        public decimal PricePerNight { get; set; }  // Odanın gecelik fiyatı.
        public RoomStatus RoomStatus { get; set; }  // Odanın durumu (Boş, Dolu, Bakımda).
        public bool HasBalcony { get; set; }        // Oda balkona sahip mi?
        public bool HasMinibar { get; set; }        // Oda minibara sahip mi?
        public bool HasAirConditioner { get; set; } // Oda klima içeriyor mu?
        public bool HasTV { get; set; }             // Oda TV içeriyor mu?
        public bool HasHairDryer { get; set; }      // Oda saç kurutma makinesi içeriyor mu?
        public bool HasWifi { get; set; }           // Oda WiFi içeriyor mu?

        // Foreign Keys
        public int RoomTypeId { get; set; } // Odanın türü.

        // Relational Properties
        public virtual RoomType RoomType { get; set; }                      // 1 RoomType N Room, 1 Room 1 RoomType
        public virtual ICollection<Reservation> Reservations { get; set; }  // 1 Room N Reservation, 1 Reservation 1 Room
    }
}
