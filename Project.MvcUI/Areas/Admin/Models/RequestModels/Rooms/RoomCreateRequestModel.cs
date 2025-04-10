using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    /// <summary>
    /// Yeni oda oluşturma işlemlerinde kullanılan request model.
    /// Kat, fiyat, oda tipi ve donanım bilgilerini içerir.
    /// </summary>
    public class RoomCreateRequestModel
    {
        /// <summary>Oda numarası (zorunlu ve 3 basamaklı rakamlardan oluşmalıdır).</summary>
        [Required(ErrorMessage = "Oda numarası gereklidir.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Oda numarası 3 basamaklı ve yalnızca rakamlardan oluşmalıdır.")]
        public string RoomNumber { get; set; }

        /// <summary>Odanın bulunduğu kat (1 ile 4 arasında olmalıdır).</summary>
        [Required(ErrorMessage = "Kat numarası gereklidir.")]
        [Range(1, 4, ErrorMessage = "Kat numarası 1 ile 4 arasında olmalıdır.")]
        public int Floor { get; set; }

        /// <summary>Gecelik konaklama fiyatı (zorunlu ve sıfırdan büyük olmalıdır).</summary>
        [Required(ErrorMessage = "Oda fiyatı gereklidir.")]
        [Range(1, double.MaxValue, ErrorMessage = "Oda fiyatı sıfırdan büyük olmalıdır.")]
        public decimal PricePerNight { get; set; }

        /// <summary>Seçilen oda tipi ID'si (zorunlu).</summary>
        [Required(ErrorMessage = "Oda tipi seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir oda tipi seçilmelidir.")]
        public int RoomTypeId { get; set; }

        // Donanım Özellikleri
        [Display(Name = "Balkon")]
        public bool HasBalcony { get; set; }

        [Display(Name = "Minibar")]
        public bool HasMinibar { get; set; }

        [Display(Name = "Klima")]
        public bool HasAirConditioner { get; set; }

        [Display(Name = "TV")]
        public bool HasTV { get; set; }

        [Display(Name = "Saç Kurutma Makinesi")]
        public bool HasHairDryer { get; set; }

        [Display(Name = "WiFi")]
        public bool HasWifi { get; set; }
    }
}
