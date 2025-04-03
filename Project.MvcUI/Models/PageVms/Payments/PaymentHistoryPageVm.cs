using Project.MvcUI.Models.PureVms.Payments.ResponseModels;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme Geçmişi sayfası için Page View Model.
    /// API'den dönen PaymentHistoryResponseModel listesini ve UI'ya özgü ek bilgileri taşır.
    /// </summary>
    public class PaymentHistoryPageVm 
    {
        public PaymentHistoryPageVm()
        {
            PaymentHistoryList = new List<PaymentHistoryResponseModel>();
            PageTitle = "Ödeme Geçmişim";
            HelpText = "Ödeme geçmişinizi aşağıda görebilirsiniz.";
        }

        /// <summary>
        /// API'den alınan ödeme geçmişi verilerini içeren liste.
        /// </summary>
        public List<PaymentHistoryResponseModel> PaymentHistoryList { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Yardım metni veya açıklama.
        /// </summary>
        public string? HelpText { get; set; }

        /// <summary>
        /// Ek hata mesajları.
        /// </summary>
        public string? ErrorMessage { get; set; }
    }
}
