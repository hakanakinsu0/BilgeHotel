namespace Project.MvcUI.Models.PureVms.Payments.ResponseModels
{
    /// <summary>
    /// Ödeme geçmişiyle ilgili bilgileri içerir.
    /// Bu model, ödeme işlemleriyle ilgili temel verileri (rezervasyon numarası, kart sahibi, kart numarası, ödeme tutarı, oda numarası, CVV) taşır.
    /// </summary>
    public class PaymentHistoryResponseModel
    {
        /// <summary>
        /// Rezervasyonun benzersiz numarası.
        /// </summary>
        public int ReservationId { get; set; }  

        /// <summary>
        /// Kart sahibinin adı ve soyadı.
        /// </summary>
        public string CardUserName { get; set; }

        /// <summary>
        /// Kullanılan kartın numarası.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Yapılan ödemenin toplam tutarı.
        /// </summary>
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Rezervasyonun ait olduğu oda numarası.
        /// </summary>
        public string RoomNumber { get; set; }

        /// <summary>
        /// Kartın CVV numarası.
        /// Bu değer, API’den dinamik olarak alınacaktır.
        /// </summary>
        public string CVV { get; set; }
    }
}
