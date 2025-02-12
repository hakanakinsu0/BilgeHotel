using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers
{
    /// <summary>
    /// Kullanıcının giriş yaparken kullanacağı ViewModel.
    /// </summary>
    public class UserSignInRequestModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string UserName { get; set; } // Kullanıcı adı

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; } // Şifre

        public bool RememberMe { get; set; } // Beni Hatırla
    }
}