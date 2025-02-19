using System;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.ReservationModels
{
    public class ReservationUpdateRequestModel
    {
        [Required]
        public int Id { get; set; } // ✅ Güncellenecek rezervasyon ID

        [Required]
        public DateTime StartDate { get; set; } // ✅ Başlangıç tarihi

        [Required]
        public DateTime EndDate { get; set; } // ✅ Bitiş tarihi

        [Required]
        public decimal TotalPrice { get; set; } // ✅ Toplam tutar

        [Required]
        public int RoomId { get; set; } // ✅ Oda ID

        public int? CustomerId { get; set; } // Müşteri ID (Opsiyonel)
        public int? PackageId { get; set; } // Paket ID (Opsiyonel)
        public int? EmployeeId { get; set; } // Çalışan ID (Opsiyonel)
    }
}
