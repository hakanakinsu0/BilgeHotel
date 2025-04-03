using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    /// <summary>
    /// Ödeme onay (checkout) sürecinde kullanılan form verilerini temsil eder.
    /// Rezervasyon ID'si, müşteri adı ve toplam ödeme tutarını içerir.
    /// </summary>
    public class PaymentCheckoutRequestModel
    {
        /// <summary>
        /// Ödeme yapılacak rezervasyonun ID'si.
        /// </summary>
        [Display(Name = "Rezervasyon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        /// <summary>
        /// Ödemeyi yapan müşterinin adı.
        /// </summary>
        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Ödenmesi gereken toplam tutar.
        /// </summary>
        [Display(Name = "Toplam Tutar")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "{0} 0'dan büyük olmalıdır.")]
        public decimal TotalAmount { get; set; }
    }
}
