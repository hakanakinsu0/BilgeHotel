using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    public class UserLoginRequestModel
    {
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "E-Posta Adresi")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; } // Girişten sonra yönlendirme için
    }
}
