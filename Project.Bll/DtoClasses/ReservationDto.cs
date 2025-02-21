using System;
using System.Collections.Generic;

namespace Project.Bll.DtoClasses
{
    public class ReservationDto : BaseDto
    {
        public DateTime StartDate { get; set; } // Rezervasyon başlangıç tarihi
        public DateTime EndDate { get; set; } // Rezervasyon bitiş tarihi
        public decimal TotalPrice { get; set; } // Rezervasyon toplam tutarı

        public int? CustomerId { get; set; } // Rezervasyonu yapan müşteri
        public int RoomId { get; set; } // Rezerve edilen oda
        public int? PackageId { get; set; } // Rezervasyon için seçilen paket
        public int? EmployeeId { get; set; } // Rezervasyonu yöneten Employee (Opsiyonel)

        public string CustomerName { get; set; } // Müşteri adı ve soyadı
        public string RoomNumber { get; set; } // Oda numarası
        public string PackageName { get; set; } // Seçilen paket adı
        public string EmployeeName { get; set; } // Rezervasyonu yöneten çalışanın adı

        public List<ReservationExtraServiceDto> ExtraServices { get; set; } // Ekstra hizmetler listesi
    }
}
