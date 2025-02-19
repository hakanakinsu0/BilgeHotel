using Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.PaymentModels;

namespace Project.MvcUI.Areas.Admin.Models.PageVms
{
    public class PaymentPageVm
    {
        public List<PaymentResponseModel> Payments { get; set; } = new();
        public decimal TotalRevenue { get; set; } // Toplam gelir
        public decimal PendingPayments { get; set; } // Bekleyen ödemeler
        public decimal RefundedPayments { get; set; } // İptal edilen ödemeler
    }
}
