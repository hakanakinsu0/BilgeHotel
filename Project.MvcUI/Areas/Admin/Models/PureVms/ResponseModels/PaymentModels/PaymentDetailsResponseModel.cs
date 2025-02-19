namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.PaymentModels
{
    public class PaymentDetailsResponseModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public string? TransactionId { get; set; } // Banka işlemi referans kodu
        public string? Notes { get; set; }
    }
}
