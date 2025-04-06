using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers
{
    public class UpdateUserRequestModel
    {
        [Display(Name = "Kullanıcı ID")]
        public int Id { get; set; } // Kullanıcı ID

        // 📌 Kullanıcı Kimlik Bilgileri
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string LastName { get; set; }

        [Display(Name = "E-posta Adresi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [RegularExpression(@"^05\d{9}$", ErrorMessage = "Telefon 11 haneli olmalıdır (05xxxxxxxxx).")]
        public string PhoneNumber { get; set; }

        // 📌 Kullanıcı Profil Bilgileri
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Uyruğu")]
        public string Nationality { get; set; } // Uyruğu

        [Display(Name = "Kimlik Numarası")]
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "T.C. Kimlik Numarası 11 rakamdan oluşmalıdır.")]
        public string IdentityNumber { get; set; } // TC Kimlik No / Pasaport No

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public Gender Gender { get; set; }

        // 📌 Rol Seçimi
        [Display(Name = "Kullanıcı Rolü")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public string Role { get; set; } // Admin / Member gibi

        // 📌 Kullanıcı Aktif/Pasif Durumu
        [Display(Name = "Aktif/Pasif Durum")]
        public bool IsActive { get; set; }
    }
}
