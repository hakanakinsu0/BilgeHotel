using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationPaymentUpdateRequestModel
    {
        [Display(Name = "Rezervasyon ID")]
        public int ReservationId { get; set; } // Güncellenecek rezervasyon ID'si

        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; } // Müşteri adı (readonly gösterilecek)

        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; } // Oda numarası (readonly gösterilecek)

        [Display(Name = "Yeni Ödeme Durumu")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public ReservationStatus NewStatus { get; set; } // Yeni ödeme durumu

        [Display(Name = "Mevcut Durum")]
        public ReservationStatus CurrentStatus { get; set; } // Mevcut durum (readonly gösterilecek)
    }
}
