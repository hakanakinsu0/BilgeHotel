namespace Project.MvcUI.Models.PureVms.Payments.ResponseModels
{
    public class PaymentCheckoutResponseModel
    {
        public bool IsSuccess { get; set; } // Ödeme başarılı mı?
        public string Message { get; set; } // API'den dönen mesaj
    }
}
