using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.AppUsers
{
    /// <summary>
    /// Kullanıcının şifresini değiştirmek için kullanılan model.
    /// Yeni şifre ve tekrar alanlarını içerir.
    /// </summary>
    public class ChangePasswordRequestModel
    {
        /// <summary>
        /// Şifresi değiştirilecek kullanıcının ID'si.
        /// </summary>
        [Display(Name = "Kullanıcı ID")]
        public int Id { get; set; }

        /// <summary>
        /// Kullanıcının yeni şifresi.
        /// En az 6 karakter olmalı.
        /// </summary>
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "{0} zorunludur.")]
        [MinLength(6, ErrorMessage = "{0} en az {1} karakter olmalıdır.")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Yeni şifrenin doğrulama alanı.
        /// Yeni şifreyle aynı olmalıdır.
        /// </summary>
        [Display(Name = "Yeni Şifre (Tekrar)")]
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Compare("NewPassword", ErrorMessage = "Yeni şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
    }
}
