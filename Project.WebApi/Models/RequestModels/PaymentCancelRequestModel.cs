using System.ComponentModel.DataAnnotations;

namespace Project.WebApi.Models.RequestModels
{
    /// <summary>
    /// Ödeme iptali sırasında gönderilen verileri taşıyan request modelidir.
    /// Kart bilgileri doğrulanarak iade işlemi gerçekleştirilir.
    /// </summary>
    public class PaymentCancelRequestModel
    {
        [Display(Name = "Kart Numarası")]
        public string CardNumber { get; set; }          // Ödeme yapılan kartın numarası

        [Display(Name = "Kart Sahibi Adı")]
        public string CardUserName { get; set; }        // Kart sahibinin adı

        [Display(Name = "CVV")]
        public string CVV { get; set; }                 // Kartın arkasındaki güvenlik kodu

        [Display(Name = "İade Tutarı")]
        public decimal RefundAmount { get; set; }       // Geri yüklenecek tutar
    }
}
