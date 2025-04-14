using System.ComponentModel.DataAnnotations;

namespace Project.WebApi.Models.RequestModels
{
    /// <summary>
    /// Ödeme işlemi başlatılırken kullanılan request modelidir.
    /// Kart bilgileri, son kullanma tarihi ve alışveriş tutarını içerir.
    /// </summary>
    public class PaymentRequestModel
    {
        [Display(Name = "Kart Numarası")]
        public string CardNumber { get; set; }           // Kart numarası (ör. "1234 5678 9012 3456")

        [Display(Name = "Kart Sahibi Adı")]
        public string CardUserName { get; set; }         // Kart sahibi (ör. "Ahmet Yılmaz")

        [Display(Name = "CVV")]
        public string CVV { get; set; }                  // Kartın güvenlik kodu (ör. "123")

        [Display(Name = "Son Kullanma Yılı")]
        public int ExpiryYear { get; set; }              // Kartın geçerlilik yılı (ör. 2025)

        [Display(Name = "Son Kullanma Ayı")]
        public int ExpiryMonth { get; set; }             // Kartın geçerlilik ayı (ör. 12)

        [Display(Name = "Alışveriş Tutarı")]
        public decimal ShoppingPrice { get; set; }       // Ödenecek toplam tutar (örn. 1800.00 ₺)
    }
}
