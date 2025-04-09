using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers
{
    public class ChangePasswordRequestModel
    {
        [Display(Name = "Kullanıcı ID")]
        public int Id { get; set; }

        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        public string NewPassword { get; set; }

        [Display(Name = "Yeni Şifre (Tekrar)")]
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
