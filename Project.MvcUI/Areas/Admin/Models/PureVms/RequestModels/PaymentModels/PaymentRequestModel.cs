using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.PaymentModels
{
    public class PaymentRequestModel
    {
        [Required]
        public int ReservationId { get; set; } // Ödeme hangi rezervasyona ait?

        [Required]
        public decimal Amount { get; set; } // Ödenen miktar

        [Required]
        public string PaymentMethod { get; set; } // Kredi Kartı, Nakit, Havale

        public string? TransactionId { get; set; } // Banka işlemi referans kodu
    }
}
