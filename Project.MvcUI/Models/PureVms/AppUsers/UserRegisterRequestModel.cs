using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Project.MvcUI.Models.PureVms.AppUsers
{
    /// <summary>
    /// Kullanıcı kayıt işlemi için kullanılan ViewModel.
    /// </summary>
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string UserName { get; set; } // Kullanıcı adı

        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "E-posta adresi geçerli değil.")]
        public string Email { get; set; } // E-posta adresi

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; } // Şifre

        [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; } // Şifre doğrulama
    }
}
