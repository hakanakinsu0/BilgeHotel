using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserChangePasswordRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mevcut Şifre")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
