using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    public class RevenueReportResponseModel
    {
        public decimal TotalRevenue { get; set; } // Toplam otel geliri
        public List<MonthlyRevenueReportResponseModel> MonthlyRevenueReports { get; set; } // Aylık bazda gelir raporları
    }
}
