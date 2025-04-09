using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    public class RoomDeleteRequestModel
    {
        [Display(Name = "Oda Numarası")]
        public int RoomId { get; set; }

        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; }

        [Display(Name = "Kat")]
        public int Floor { get; set; }

        [Display(Name = "Gecelik Fiyat")]
        public decimal PricePerNight { get; set; }

        [Display(Name = "Oda Tipi")]
        public string RoomTypeName { get; set; }

        [Display(Name = "Oda Durumu")]
        public RoomStatus RoomStatus { get; set; }

        [Display(Name = "Aktif Rezervasyon Var mı?")]
        public bool HasActiveReservations { get; set; }
    }
}
