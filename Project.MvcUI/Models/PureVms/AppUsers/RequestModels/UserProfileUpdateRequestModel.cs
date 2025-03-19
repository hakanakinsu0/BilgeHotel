using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserProfileUpdateRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")] // {0} "Ad" değerini alır
        [Display(Name = "Ad")] // Alanın görüntülenecek adı
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0} 11 haneli olmalıdır. (05554443322)")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "{0} belirtmelisiniz.")]
        [Display(Name = "Uyruk")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0} 11 haneli olmalıdır.")]
        [Display(Name = "TC Kimlik Numarası")]
        public string IdentityNumber { get; set; } // **TC Kimlik No**
    }
}
