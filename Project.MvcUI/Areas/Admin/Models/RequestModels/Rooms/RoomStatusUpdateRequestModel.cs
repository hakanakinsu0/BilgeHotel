using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    /// <summary>
    /// Oda durumu güncelleme formu için kullanılan model.
    /// Kullanıcının yeni durumu seçmesini sağlar, mevcut durumu da taşır.
    /// </summary>
    public class RoomStatusUpdateRequestModel
    {
        /// <summary>Güncellenecek odanın ID bilgisi.</summary>
        [Display(Name = "Oda ID")]
        public int RoomId { get; set; }

        /// <summary>Oda numarası (sadece okunabilir olarak gösterilir).</summary>
        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; }

        /// <summary>Yeni seçilecek oda durumu (Boş, Dolu, Bakımda vs.).</summary>
        [Required(ErrorMessage = "Lütfen bir oda durumu seçin.")]
        [Display(Name = "Yeni Durum")]
        public RoomStatus NewStatus { get; set; }

        /// <summary>Mevcut oda durumu (sadece görüntüleme amaçlı).</summary>
        [Display(Name = "Mevcut Durum")]
        public RoomStatus CurrentStatus { get; set; }
    }
}
