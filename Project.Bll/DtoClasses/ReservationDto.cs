using Project.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Project.Bll.DtoClasses
{
    public class ReservationDto : BaseDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }

        public int? CustomerId { get; set; } // Rezervasyonu yapan müşteri
        public int RoomId { get; set; }
        public int? PackageId { get; set; }
        public int? EmployeeId { get; set; }

        public string CustomerName { get; set; } // 🔥 AppUser'dan Çekilecek
        public string CustomerEmail { get; set; } // 🔥 AppUser'dan Çekilecek
        public string RoomNumber { get; set; }
        public string PackageName { get; set; }
        public string EmployeeName { get; set; }

        public ReservationStatus ReservationStatus { get; set; }
        public DataStatus Status { get; set; }

        public List<ReservationExtraServiceDto> ExtraServices { get; set; }
        public int? AppUserId { get; set; }
    }
}
