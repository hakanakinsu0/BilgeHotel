namespace Project.WebApi.Models.Entities
{
    /// <summary>
    /// Kullanıcıya ait kredi kartı bilgilerini temsil eder.
    /// Bu sınıf, ödeme işlemlerinde kullanılmak üzere kart sahibinin adı, kart numarası, CVV ve bakiye gibi bilgileri barındırır.
    /// </summary>
    public class UserCardInfo : BaseEntity
    {
        public string CardUserName { get; set; }   // Kart sahibinin adı (örn: "Ahmet Yılmaz")
        public string CardNumber { get; set; }     // Kart numarası (örn: "1234 5678 9012 3456")
        public string CVV { get; set; }            // Kartın güvenlik kodu (CVV) — 3 haneli
        public int ExpiryYear { get; set; }        // Kartın son kullanma yılı (örn: 2025)
        public int ExpiryMonth { get; set; }       // Kartın son kullanma ayı (örn: 12)
        public decimal CardLimit { get; set; }     // Kartın toplam harcama limiti (örn: 10000 ₺)
        public decimal Balance { get; set; }       // Mevcut kart bakiyesi (örneğin: 5000 ₺)
    }
}
