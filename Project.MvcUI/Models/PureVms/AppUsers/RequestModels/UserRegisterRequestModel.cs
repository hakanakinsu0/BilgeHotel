using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter olmalıdır.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
            ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
