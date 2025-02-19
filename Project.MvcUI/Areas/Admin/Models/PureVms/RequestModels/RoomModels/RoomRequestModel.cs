using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.RoomModels
{
    public class RoomRequestModel
    {
        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; } // Odanın tipi (Standart, Suit vb.)

        [Required]
        public int Capacity { get; set; } // Oda kapasitesi

        [Required]
        public decimal PricePerNight { get; set; } // Gecelik ücret

        public bool IsAvailable { get; set; } = true; // Oda şu an müsait mi?

        public string? Description { get; set; }
    }
}
