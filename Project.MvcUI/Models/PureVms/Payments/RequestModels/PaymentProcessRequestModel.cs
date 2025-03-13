using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    public class PaymentProcessRequestModel
    {
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Kart sahibi adı gereklidir.")]
        public string CardUserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kart numarası gereklidir.")]
        [StringLength(19, MinimumLength = 16, ErrorMessage = "Kart numarası 16-19 karakter olmalıdır.")]
        public string CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "CVV gereklidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV 3 haneli olmalıdır.")]
        public string CVV { get; set; } = string.Empty;

        [Required(ErrorMessage = "Son Kullanım Ayı gereklidir.")]
        [Range(1, 12, ErrorMessage = "Geçerli bir ay seçin.")]
        public int ExpiryMonth { get; set; }

        [Required(ErrorMessage = "Son Kullanım Yılı gereklidir.")]
        [Range(2024, 2035, ErrorMessage = "Geçerli bir yıl seçin.")]
        public int ExpiryYear { get; set; }

        [Required(ErrorMessage = "Tutar gereklidir.")]
        public decimal ShoppingPrice { get; set; }  // ✅ **ShoppingPrice olarak değiştirildi**


    }
}
