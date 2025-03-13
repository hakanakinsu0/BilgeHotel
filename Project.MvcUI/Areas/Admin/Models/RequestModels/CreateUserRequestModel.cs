using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels
{
    public class CreateUserRequestModel
    {
        // 📌 Kullanıcı Kimlik Bilgileri
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı gereklidir.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        // 📌 Profil Bilgileri
        [Required(ErrorMessage = "Ad gereklidir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir.")]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; } // Opsiyonel

        [Required(ErrorMessage = "Cinsiyet seçilmelidir.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Adres bilgisi gereklidir.")]
        public string Address { get; set; }

        public string Nationality { get; set; } // Uyruğu
        public string IdentityNumber { get; set; } // TC Kimlik No / Pasaport No

        // 📌 Rol Seçimi
        [Required(ErrorMessage = "Kullanıcı rolü seçilmelidir.")]
        public string Role { get; set; } // Admin / Member gibi
    }
}
