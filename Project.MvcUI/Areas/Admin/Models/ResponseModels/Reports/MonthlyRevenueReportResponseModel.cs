namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Aylık gelir bilgilerini temsil eden modeldir.
    /// Belirli bir yıl ve ay için hesaplanan toplam geliri içerir.
    /// </summary>
    public class MonthlyRevenueReportResponseModel
    {
        public int Year { get; set; } // Gelirin ait olduğu yıl (örnek: 2025)
        public int Month { get; set; } // Gelirin ait olduğu ay (1-12)
        public decimal TotalRevenue { get; set; } // Aylık toplam gelir
    }
}
