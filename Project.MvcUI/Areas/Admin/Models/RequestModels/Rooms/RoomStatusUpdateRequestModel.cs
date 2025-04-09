using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomStatusUpdateRequestModel
    {
        [Display(Name = "Oda ID")]
        public int RoomId { get; set; } // Güncellenecek oda ID'si

        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; } // Oda numarası (readonly gösterilecek)

        [Required(ErrorMessage = "Lütfen bir oda durumu seçin.")]
        [Display(Name = "Yeni Durum")]
        public RoomStatus NewStatus { get; set; } // Yeni oda durumu

        [Display(Name = "Mevcut Durum")]
        public RoomStatus CurrentStatus { get; set; } // Mevcut durum (readonly gösterilecek)
    }
}
