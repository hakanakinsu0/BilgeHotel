namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    public class MonthlyRevenueReportResponseModel
    {
        public int Year { get; set; } // Yıl bilgisi
        public int Month { get; set; } // Ay bilgisi (1-12)
        public decimal TotalRevenue { get; set; } // O ayki toplam gelir
    }
}
