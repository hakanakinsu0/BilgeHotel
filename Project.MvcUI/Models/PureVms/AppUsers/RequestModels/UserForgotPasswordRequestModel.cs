using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    /// <summary>
    /// Şifremi unuttum işlemi için kullanıcıdan e-posta adresini almak üzere kullanılan request modelidir.
    /// </summary>
    public class UserForgotPasswordRequestModel
    {
        /// <summary>
        /// Kullanıcının e-posta adresidir.
        /// Şifre sıfırlama bağlantısı bu adrese gönderilecektir.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")] // {0} burada Display Name'i temsil eder
        [EmailAddress(ErrorMessage = "Geçerli bir {0} giriniz.")] // {0} burada Display Name'i temsil eder
        [Display(Name = "E-posta Adresi")] // Görüntülenecek alan adı
        public string Email { get; set; }
    }
}
