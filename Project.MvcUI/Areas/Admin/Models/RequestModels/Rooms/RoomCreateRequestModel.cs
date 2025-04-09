using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomCreateRequestModel
    {
        [Required(ErrorMessage = "Oda numarası gereklidir.")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Oda numarası 3 basamaklı ve yalnızca rakamlardan oluşmalıdır.")]
        public string RoomNumber { get; set; }


        [Required(ErrorMessage = "Kat numarası gereklidir.")]
        [Range(1, 4, ErrorMessage = "Kat numarası 1 ile 4 arasında olmalıdır.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Oda fiyatı gereklidir.")]
        [Range(1, double.MaxValue, ErrorMessage = "Oda fiyatı sıfırdan büyük olmalıdır.")]
        public decimal PricePerNight { get; set; }

        [Required(ErrorMessage = "Oda tipi seçilmelidir.")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir oda tipi seçilmelidir.")]
        public int RoomTypeId { get; set; }

        // Özellikler
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
