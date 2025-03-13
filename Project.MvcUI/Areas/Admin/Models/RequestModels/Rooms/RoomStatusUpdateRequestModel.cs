using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomStatusUpdateRequestModel
    {
        public int RoomId { get; set; } // Güncellenecek oda ID'si

        public string RoomNumber { get; set; } // Oda numarası (readonly gösterilecek)

        [Required(ErrorMessage = "Lütfen bir oda durumu seçin.")]
        public RoomStatus NewStatus { get; set; } // Yeni oda durumu

        public RoomStatus CurrentStatus { get; set; } // Mevcut durum (readonly gösterilecek)
    }
}
