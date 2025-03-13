namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    public class PaymentCheckoutRequestModel
    {
        public int ReservationId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; } // **ShoppingPrice yerine doğru isim TotalAmount**
    }
}
