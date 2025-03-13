using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomUpdateRequestModel
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Oda numarası gereklidir.")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Kat numarası gereklidir.")]
        [Range(1, 100, ErrorMessage = "Kat numarası 1 ile 100 arasında olmalıdır.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Oda fiyatı gereklidir.")]
        [Range(1, double.MaxValue, ErrorMessage = "Oda fiyatı sıfırdan büyük olmalıdır.")]
        public decimal PricePerNight { get; set; }

        [Required(ErrorMessage = "Oda tipi seçilmelidir.")]
        public int RoomTypeId { get; set; }

        public RoomStatus RoomStatus { get; set; } // Odanın mevcut durumu (doluysa değiştirilemez)

        // ✅ Özellikler
        public bool HasBalcony { get; set; }
        public bool HasMinibar { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasTV { get; set; }
        public bool HasHairDryer { get; set; }
        public bool HasWifi { get; set; }
    }
}
