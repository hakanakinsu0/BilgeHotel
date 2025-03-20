using Project.MvcUI.Models.PureVms.Payments.RequestModels;
using Project.MvcUI.Models.PureVms.Payments.ResponseModels;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme iptali sayfası için Page View Model.
    /// Hem PaymentCancelRequestModel (form verilerini) hem de PaymentCancelResponseModel (API’den dönen sonucu)
    /// ve UI’ya özgü ek bilgileri içerir.
    /// </summary>
    public class PaymentCancelPageVm
    {
        public PaymentCancelPageVm()
        {
            // Varsayılan değerler atandı
            PageTitle = "Ödeme İptali";
            HelpText = "Lütfen ödeme iptali işlemi için bilgileri kontrol ediniz.";
            PaymentCancelRequest = new PaymentCancelRequestModel();
        }

        /// <summary>
        /// Ödeme iptali form verilerini içeren model.
        /// </summary>
        public PaymentCancelRequestModel PaymentCancelRequest { get; set; }

        /// <summary>
        /// API'den dönen iptal işlemi sonucunu içeren model (varsa).
        /// </summary>
        public PaymentCancelResponseModel? PaymentCancelResponse { get; set; }

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
