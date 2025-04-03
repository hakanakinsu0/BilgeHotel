using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    /// <summary>
    /// Kullanıcının giriş işlemi için gerekli verileri taşıyan request modelidir.
    /// E-posta ve şifre alanları ile birlikte opsiyonel olarak yönlendirme URL'si içerir.
    /// </summary>
    public class UserLoginRequestModel
    {
        /// <summary>
        /// Kullanıcının giriş yaparken kullandığı e-posta adresidir.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "E-Posta Adresi")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının hesabına erişim için gerekli şifredir.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        /// <summary>
        /// Giriş işleminden sonra yönlendirilecek opsiyonel URL bilgisidir.
        /// </summary>
        public string? ReturnUrl { get; set; }
    }
}
