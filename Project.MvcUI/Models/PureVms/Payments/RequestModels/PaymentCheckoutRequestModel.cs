using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    public class PaymentCheckoutRequestModel
    {
        [Display(Name = "Rezervasyon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CustomerName { get; set; } 

        [Display(Name = "Toplam Tutar")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "{0} 0'dan büyük olmalıdır.")]
        public decimal TotalAmount { get; set; } 
    }
}
