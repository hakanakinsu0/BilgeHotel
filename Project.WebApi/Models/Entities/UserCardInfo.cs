namespace Project.WebApi.Models.Entities
{
    public class UserCardInfo : BaseEntity
    {
        public string CardUserName { get; set; }  // Kart Sahibinin Adı
        public string CardNumber { get; set; }  // Kart Numarası
        public string CVV { get; set; }  // Kartın CVV Kodu
        public int ExpiryYear { get; set; }  // Son Kullanma Yılı
        public int ExpiryMonth { get; set; }  // Son Kullanma Ayı
        public decimal CardLimit { get; set; }  // Kartın Aylık Harcama Limiti
        public decimal Balance { get; set; }  // Kullanıcının mevcut kart bakiyesi
    }
}
