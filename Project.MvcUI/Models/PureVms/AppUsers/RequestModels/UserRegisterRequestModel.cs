using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    /// <summary>
    /// Kullanıcının kayıt (register) işlemi sırasında ihtiyaç duyulan verileri tutan request modelidir.
    /// Kullanıcı adı, e-posta ve şifre alanlarını içerir.
    /// </summary>
    public class UserRegisterRequestModel
    {
        /// <summary>
        /// Kullanıcının sistemde kullanacağı kullanıcı adı.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(3, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        /// <summary>
        /// Kullanıcının geçerli bir e-posta adresi.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının belirleyeceği şifre.
        /// En az 6 karakter olmalı, büyük harf, küçük harf ve rakam içermelidir.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "{0} en az bir büyük harf, bir küçük harf ve bir rakam içermelidir.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        /// <summary>
        /// Kullanıcının şifresini tekrar girmesi gereken alan.
        /// Girilen şifre ile eşleşmelidir.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("Password", ErrorMessage = "{0} ile {1} eşleşmiyor.")]
        [Display(Name = "Şifre Tekrar")]
        public string ConfirmPassword { get; set; }
    }
}
