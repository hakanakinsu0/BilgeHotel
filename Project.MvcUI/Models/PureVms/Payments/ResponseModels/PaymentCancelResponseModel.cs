namespace Project.MvcUI.Models.PureVms.Payments.ResponseModels
{
    /// <summary>
    /// Ödeme iptali işlemi sonucunu temsil eden model.
    /// </summary>
    public class PaymentCancelResponseModel
    {
        /// <summary>
        /// İptal işleminin başarılı olup olmadığını belirtir.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// İptal işlemiyle ilgili mesaj veya hata bilgisi.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}
