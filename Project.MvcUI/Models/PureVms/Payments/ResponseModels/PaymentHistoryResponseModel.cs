namespace Project.MvcUI.Models.PureVms.Payments.ResponseModels
{
    public class PaymentHistoryResponseModel
    {
        public int ReservationId { get; set; }  // ✅ Rezervasyon ID eklendi!
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public decimal PaymentAmount { get; set; }
        public string RoomNumber { get; set; }
        public string CVV { get; set; } = string.Empty; // **API’den dinamik olarak alınacak**

    }

}
