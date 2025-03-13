using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationPaymentUpdateRequestModel
    {
        public int ReservationId { get; set; } // Güncellenecek rezervasyon ID'si

        public string CustomerName { get; set; } // Müşteri adı (readonly gösterilecek)

        public string RoomNumber { get; set; } // Oda numarası (readonly gösterilecek)

        [Required(ErrorMessage = "Lütfen yeni ödeme durumunu seçin.")]
        public ReservationStatus NewStatus { get; set; } // Yeni ödeme durumu

        public ReservationStatus CurrentStatus { get; set; } // Mevcut durum (readonly gösterilecek)
    }
}
