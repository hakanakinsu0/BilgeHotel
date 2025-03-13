namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    public class PaymentCancelRequestModel
    {
        public int ReservationId { get; set; }
        public string CardUserName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty; // **API’den dinamik olarak alınacak**
        public decimal RefundAmount { get; set; } // Kullanıcıya geri iade edilecek tutar
        public string RoomNumber { get; set; } 

    }
}
