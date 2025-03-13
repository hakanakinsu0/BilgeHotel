namespace Project.WebApi.Models.ResponseModels
{
    public class PaymentHistoryResponseModel
    {
        public string CVV { get; set; } = string.Empty;

        public string CardUserName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string RoomNumber { get; set; } = string.Empty;  // 🏨 **Ödeme yapılan oda numarası**
        public decimal PaymentAmount { get; set; }  // 💰 **Ödeme tutarı**
    }
}
