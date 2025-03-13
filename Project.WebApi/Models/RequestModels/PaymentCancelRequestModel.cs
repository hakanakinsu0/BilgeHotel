namespace Project.WebApi.Models.RequestModels
{
    public class PaymentCancelRequestModel
    {
        public string CardNumber { get; set; }
        public string CardUserName { get; set; }
        public string CVV { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
