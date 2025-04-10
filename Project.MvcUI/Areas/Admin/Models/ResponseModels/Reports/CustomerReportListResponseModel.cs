using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// Müşteri raporlama ekranında kullanılmak üzere;
    /// toplam müşteri sayısı, rezervasyon durumu istatistikleri ve müşteri detaylarını taşıyan modeldir.
    /// </summary>
    public class CustomerReportListResponseModel
    {
        public int TotalCustomers { get; set; } // Tüm müşterilerin toplam sayısı
        public int CustomersWithReservations { get; set; } // En az bir rezervasyon yapmış müşterilerin sayısı
        public int CustomersWithoutReservations { get; set; } // Hiç rezervasyon yapmamış müşterilerin sayısı
        public List<CustomerReportResponseModel> Customers { get; set; } // Her müşteriye ait detay bilgiler listesi
    }
}
