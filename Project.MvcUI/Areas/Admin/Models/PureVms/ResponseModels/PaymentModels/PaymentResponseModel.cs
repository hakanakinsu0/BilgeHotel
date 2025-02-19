namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.PaymentModels
{
    public class PaymentResponseModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; } // Tamamlandı, Bekliyor, İptal Edildi
    }
}
