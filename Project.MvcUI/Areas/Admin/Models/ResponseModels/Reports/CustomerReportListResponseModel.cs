using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Reports
{
    /// <summary>
    /// UI tarafında müşteri raporu listesini temsil eden model.
    /// Bu model, toplam müşteri sayısı, rezervasyon yapan ve yapmayan müşteri sayıları ile
    /// her bir müşteriye ait detayları içeren listeyi kapsar.
    /// </summary>
    public class CustomerReportListResponseModel
    {
        public int TotalCustomers { get; set; }                 // Otelde kayıtlı toplam müşteri sayısı

        public int CustomersWithReservations { get; set; }      // Rezervasyon yapmış müşteri sayısı

        public int CustomersWithoutReservations { get; set; }   // Henüz rezervasyon yapmamış müşteri sayısı

        public List<CustomerReportResponseModel> Customers { get; set; } // Her bir müşteriye ait detayları içeren liste
    }
}
