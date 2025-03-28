using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// UI'da otel gelir raporlarını temsil eden model.
    /// Toplam otel geliri ve aylık bazda gelir raporlarını içerir.
    /// </summary>
    public class RevenueReportResponseModel
    {
        public decimal TotalRevenue { get; set; } // Toplam otel geliri
        public List<MonthlyRevenueReportResponseModel> MonthlyRevenueReports { get; set; } // Aylık bazda gelir raporları listesi
    }
}
