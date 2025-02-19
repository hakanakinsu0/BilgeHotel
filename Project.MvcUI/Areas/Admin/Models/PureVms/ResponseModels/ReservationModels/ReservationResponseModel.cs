using System;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels.ReservationModels
{
    public class ReservationResponseModel
    {
        public int Id { get; set; } // ✅ Rezervasyon ID
        public DateTime StartDate { get; set; } // ✅ Başlangıç tarihi
        public DateTime EndDate { get; set; } // ✅ Bitiş tarihi
        public decimal TotalPrice { get; set; } // ✅ Toplam tutar

        public int RoomId { get; set; } // ✅ Oda ID
        public int? CustomerId { get; set; } // Müşteri ID (Opsiyonel)
        public int? PackageId { get; set; } // Paket ID (Opsiyonel)
        public int? EmployeeId { get; set; } // Çalışan ID (Opsiyonel)

        // **UI için ekstra bilgiler**
        public string CustomerName { get; set; } // Müşteri adı
        public string RoomNumber { get; set; } // Oda numarası
        public string PackageName { get; set; } // Paket adı
        public string EmployeeName { get; set; } // Çalışan adı
    }
}
