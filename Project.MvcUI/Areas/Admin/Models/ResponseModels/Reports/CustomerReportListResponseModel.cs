using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    public class CustomerReportListResponseModel
    {
        public int TotalCustomers { get; set; } // Toplam müşteri sayısı
        public int CustomersWithReservations { get; set; } // Rezervasyon yapan müşteri sayısı
        public int CustomersWithoutReservations { get; set; } // Rezervasyon yapmayan müşteri sayısı
        public List<CustomerReportResponseModel> Customers { get; set; } // Müşteri detay listesi
    }
}
