using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Otel gelir raporlarını içeren model.
    /// Toplam gelir ve aylık gelir dağılımını içerir.
    /// </summary>
    public class RevenueReportResponseModel
    {
        public decimal TotalRevenue { get; set; } // Genel toplam gelir
        public List<MonthlyRevenueReportResponseModel> MonthlyRevenueReports { get; set; } // Aylık gelir listesi
    }
}
