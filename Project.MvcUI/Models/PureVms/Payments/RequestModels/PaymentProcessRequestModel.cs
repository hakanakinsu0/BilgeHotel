using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    /// <summary>
    /// Kullanıcının ödeme yapma işlemi sırasında dolduracağı form verilerini temsil eder.
    /// Kart bilgileri, rezervasyon numarası ve ödeme tutarını içerir.
    /// </summary>
    public class PaymentProcessRequestModel
    {
        /// <summary>
        /// Ödeme yapılacak rezervasyonun ID'si.
        /// </summary>
        [Display(Name = "Rezervasyon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        /// <summary>
        /// Kart sahibinin adı.
        /// </summary>
        [Display(Name = "Kart Sahibi Adı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CardUserName { get; set; } 

        /// <summary>
        /// Kart numarası (16-19 karakter aralığında olmalı).
        /// </summary>
        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(19, MinimumLength = 16, ErrorMessage = "{0} 16-19 karakter olmalıdır.")]
        public string CardNumber { get; set; } 

        /// <summary>
        /// Kartın arka yüzündeki güvenlik kodu (CVV).
        /// </summary>
        [Display(Name = "CVV")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "{0} 3 haneli olmalıdır.")]
        public string CVV { get; set; } 

        /// <summary>
        /// Kartın son kullanım ayı (1-12 arası).
        /// </summary>
        [Display(Name = "Son Kullanım Ayı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(1, 12, ErrorMessage = "Geçerli bir {0} seçin.")]
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// Kartın son kullanım yılı (2024-2035 arası).
        /// </summary>
        [Display(Name = "Son Kullanım Yılı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(2024, 2035, ErrorMessage = "Geçerli bir {0} seçin.")]
        public int ExpiryYear { get; set; }

        /// <summary>
        /// Ödenecek toplam tutar.
        /// </summary>
        [Display(Name = "Tutar")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public decimal ShoppingPrice { get; set; }
    }
}
