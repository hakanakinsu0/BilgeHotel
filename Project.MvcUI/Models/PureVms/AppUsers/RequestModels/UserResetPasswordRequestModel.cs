using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserResetPasswordRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Token")]
        public string Token { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
