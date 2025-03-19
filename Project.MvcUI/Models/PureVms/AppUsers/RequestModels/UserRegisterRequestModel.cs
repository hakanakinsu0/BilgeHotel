using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserRegisterRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")] // {0} yerine Display(Name) "Kullanıcı Adı" gelir
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter olmalıdır.")] // {1} 3 değeri
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("Password", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
