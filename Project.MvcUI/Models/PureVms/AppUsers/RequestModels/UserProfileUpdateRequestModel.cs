using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.AppUsers.RequestModels
{
    /// <summary>
    /// Kullanıcı profil bilgilerini güncellemek için kullanılan request modelidir.
    /// Kullanıcının kişisel bilgileri, iletişim ve kimlik bilgilerini içerir.
    /// </summary>
    public class UserProfileUpdateRequestModel
    {
        /// <summary>
        /// Kullanıcının adı.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        /// <summary>
        /// Kullanıcının soyadı.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        /// <summary>
        /// Kullanıcının telefon numarası (11 haneli).
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0} 11 haneli olmalıdır. (05554443322)")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Kullanıcının açık adres bilgisi.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        /// <summary>
        /// Kullanıcının cinsiyeti.
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Kullanıcının uyruk bilgisi (örnek: Türkiye).
        /// </summary>
        [Required(ErrorMessage = "{0} belirtmelisiniz.")]
        [Display(Name = "Uyruk")]
        public string Nationality { get; set; }

        /// <summary>
        /// Kullanıcının Türkiye Cumhuriyeti kimlik numarası (11 haneli).
        /// </summary>
        [Required(ErrorMessage = "{0} zorunludur.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "{0} 11 haneli olmalıdır.")]
        [Display(Name = "TC Kimlik Numarası")]
        public string IdentityNumber { get; set; }
    }
}
