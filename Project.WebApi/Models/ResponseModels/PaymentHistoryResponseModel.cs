using System.ComponentModel.DataAnnotations;

namespace Project.WebApi.Models.ResponseModels
{
    /// <summary>
    /// Kullanıcının ödeme geçmişine ait bilgileri temsil eder.
    /// Kart ve ödeme bilgilerini, hangi odaya ait olduğu bilgisini içerir.
    /// </summary>
    public class PaymentHistoryResponseModel
    {
        [Display(Name = "CVV")]
        public string CVV { get; set; }             // Kartın güvenlik kodu (gerçek sistemlerde gizlenmelidir)

        [Display(Name = "Kart Sahibi")]
        public string CardUserName { get; set; }    // Kart sahibinin adı

        [Display(Name = "Kart Numarası")]
        public string CardNumber { get; set; }      // Kart numarası (maskeleme önerilir)

        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; }      // 🏨 Ödeme yapılan oda numarası

        [Display(Name = "Ödeme Tutarı")]
        public decimal PaymentAmount { get; set; }  // 💰 Ödenen tutar
    }
}
