using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    public class PaymentProcessRequestModel
    {
        [Display(Name = "Rezervasyon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        [Display(Name = "Kart Sahibi Adı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CardUserName { get; set; } = string.Empty;

        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(19, MinimumLength = 16, ErrorMessage = "{0} 16-19 karakter olmalıdır.")]
        public string CardNumber { get; set; } = string.Empty;

        [Display(Name = "CVV")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0} 3 haneli olmalıdır.")]
        public string CVV { get; set; } = string.Empty;

        [Display(Name = "Son Kullanım Ayı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(1, 12, ErrorMessage = "Geçerli bir {0} seçin.")]
        public int ExpiryMonth { get; set; }

        [Display(Name = "Son Kullanım Yılı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(2024, 2035, ErrorMessage = "Geçerli bir {0} seçin.")]
        public int ExpiryYear { get; set; }

        [Display(Name = "Tutar")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public decimal ShoppingPrice { get; set; }
    }
}
