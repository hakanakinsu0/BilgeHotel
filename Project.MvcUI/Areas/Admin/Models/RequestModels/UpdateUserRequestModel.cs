using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels
{
    public class UpdateUserRequestModel
    {
        public int Id { get; set; } // Kullanıcı ID

        // 📌 Kullanıcı Kimlik Bilgileri
        [Required(ErrorMessage = "Ad gereklidir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad gereklidir.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }

        // 📌 Kullanıcı Profil Bilgileri
        public string Address { get; set; }
        public string Nationality { get; set; } // Uyruğu
        public string IdentityNumber { get; set; } // TC Kimlik No / Pasaport No

        [Required(ErrorMessage = "Cinsiyet seçilmelidir.")]
        public Gender Gender { get; set; }

        // 📌 Rol Seçimi
        [Required(ErrorMessage = "Kullanıcı rolü seçilmelidir.")]
        public string Role { get; set; } // Admin / Member gibi

        // 📌 Kullanıcı Aktif/Pasif Durumu
        public bool IsActive { get; set; }
    }
}
