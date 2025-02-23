using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserProfileUpdateRequestModel
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Adres zorunludur.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Cinsiyet zorunludur.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Uyruğunuzu belirtmelisiniz.")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "TC Kimlik Numarası zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "TC Kimlik Numarası 11 haneli olmalıdır.")]
        public string IdentityNumber { get; set; } // **TC Kimlik No**
    }
}
