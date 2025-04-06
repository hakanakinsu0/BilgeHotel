using Project.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers
{
    public class CreateUserRequestModel
    {
        // 📌 Kullanıcı Kimlik Bilgileri

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string UserName { get; set; }

        [Display(Name = "E-posta Adresi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [MinLength(6, ErrorMessage = "{0} en az 6 karakter olmalıdır.")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [MinLength(6, ErrorMessage = "{0} en az 6 karakter olmalıdır.")]
        [Compare("Password", ErrorMessage = "Şifre ve Şifre (Tekrar) eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Phone(ErrorMessage = "Geçerli bir {0} giriniz.")]
        public string PhoneNumber { get; set; }

        // 📌 Profil Bilgileri

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string LastName { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; } // Opsiyonel

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public Gender Gender { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "{0} bilgisi gereklidir.")]
        public string Address { get; set; }

        [Display(Name = "Uyruğu")]
        public string Nationality { get; set; }

        [Display(Name = "Kimlik Numarası")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "TC Kimlik No 11 rakamdan oluşmalıdır.")]
        public string IdentityNumber { get; set; }

        // 📌 Rol Seçimi

        [Display(Name = "Kullanıcı Rolü")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public string Role { get; set; } // Örneğin, Admin veya Member
    }
}
