namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// UI tarafında aylık gelir raporlarını temsil eden model.
    /// Bu model, belirli bir yıl ve ay için toplam geliri içerir.
    /// </summary>
    public class MonthlyRevenueReportResponseModel
    {
        public int Year { get; set; } // Yıl bilgisi (örn. 2025)

        public int Month { get; set; } // Ay bilgisi (1-12 arası, örn. 3 Mart)

        public decimal TotalRevenue { get; set; } // İlgili ayın toplam geliri
    }
}
