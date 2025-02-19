using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.PaymentModels
{
    public class PaymentUpdateRequestModel
    {
        [Required]
        public int Id { get; set; } // Güncellenecek ödemenin ID'si

        [Required]
        public decimal Amount { get; set; } // Güncellenmiş ödeme miktarı

        [Required]
        public string PaymentStatus { get; set; } // Tamamlandı, Bekliyor, İptal Edildi gibi durumlar

        public string? Notes { get; set; } // Admin'in ekleyebileceği ekstra notlar
    }
}
