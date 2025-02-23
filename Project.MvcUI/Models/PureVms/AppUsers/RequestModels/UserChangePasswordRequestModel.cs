using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserChangePasswordRequestModel
    {
        [Required(ErrorMessage = "Mevcut şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$",
            ErrorMessage = "Şifre en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Yeni şifre tekrarı zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
