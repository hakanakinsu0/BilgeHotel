using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    /// <summary>
    /// Kullanıcının şifresini sıfırlamak için ihtiyaç duyulan bilgileri içeren request modelidir.
    /// E-posta, token ve yeni şifre alanlarını içerir.
    /// </summary>
    public class UserResetPasswordRequestModel
    {
        /// <summary>
        /// Şifre sıfırlama işlemi için gerekli olan token değeri.
        /// Kullanıcının e-posta adresine gönderilen doğrulama kodudur.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Token")]
        public string Token { get; set; }

        /// <summary>
        /// Şifre sıfırlama işlemi için kullanıcıya ait e-posta adresi.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının belirleyeceği yeni şifre.
        /// En az 6 karakterli, büyük harf, küçük harf ve rakam içermelidir.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        [Display(Name = "Yeni Şifre")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Kullanıcının yeni şifresini tekrar girmesi gereken alan.
        /// Girilen yeni şifre ile birebir aynı olmalıdır.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
