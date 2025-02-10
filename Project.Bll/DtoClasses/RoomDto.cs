using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Otel odası verilerini taşımak için kullanılan DTO.
    /// Oda numarası, kat bilgisi, fiyat, durumu ve oda tipi ile ilgili bilgileri içerir.
    /// </summary>
    public class RoomDto : BaseDto
    {
        public string RoomNumber { get; set; } // Odanın numarası
        public int Floor { get; set; } // Odanın bulunduğu kat
        public decimal PricePerNight { get; set; } // Odanın gecelik fiyatı
        public RoomStatus RoomStatus { get; set; } // Odanın durumu (Boş, Dolu, Bakımda)
        public int RoomTypeId { get; set; } // Oda türünün ID'si
        public string RoomTypeName { get; set; } // Oda türü adı
    }
}
