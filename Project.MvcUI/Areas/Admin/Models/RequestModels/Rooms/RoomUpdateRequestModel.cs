using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    /// <summary>
    /// Oda düzenleme formu için kullanılan modeldir.
    /// Kat, fiyat, tip ve özellikler dahil olmak üzere güncellenebilir tüm alanları içerir.
    /// </summary>
    public class RoomUpdateRequestModel
    {
        /// <summary>Güncellenecek odanın ID'si.</summary>
        public int RoomId { get; set; }

        /// <summary>Oda numarası (sadece rakamlardan oluşmalı ve zorunludur).</summary>
        [RegularExpression(@"^\d+$", ErrorMessage = "Oda numarası yalnızca rakam içermelidir.")]
        [Required(ErrorMessage = "Oda numarası gereklidir.")]
        public string RoomNumber { get; set; }

        /// <summary>Kat numarası (1 ile 100 arasında olmalı).</summary>
        [Required(ErrorMessage = "Kat numarası gereklidir.")]
        [Range(1, 100, ErrorMessage = "Kat numarası 1 ile 100 arasında olmalıdır.")]
        public int Floor { get; set; }

        /// <summary>Gecelik fiyat (0'dan büyük olmalı).</summary>
        [Required(ErrorMessage = "Oda fiyatı gereklidir.")]
        [Range(1, double.MaxValue, ErrorMessage = "Oda fiyatı sıfırdan büyük olmalıdır.")]
        public decimal PricePerNight { get; set; }

        /// <summary>Oda tipi ID (zorunlu).</summary>
        [Required(ErrorMessage = "Oda tipi seçilmelidir.")]
        public int RoomTypeId { get; set; }

        /// <summary>Odanın mevcut durumu (Boş, Dolu, Bakımda). Doluyken bazı alanlar düzenlenemez.</summary>
        public RoomStatus RoomStatus { get; set; }

        // Donanım özellikleri
        public bool HasBalcony { get; set; } // Balkon var mı?
        public bool HasMinibar { get; set; } // Minibar var mı?
        public bool HasAirConditioner { get; set; } // Klima var mı?
        public bool HasTV { get; set; } // TV var mı?
        public bool HasHairDryer { get; set; } // Saç kurutma makinesi var mı?
        public bool HasWifi { get; set; } // Wi-Fi var mı?
    }
}
