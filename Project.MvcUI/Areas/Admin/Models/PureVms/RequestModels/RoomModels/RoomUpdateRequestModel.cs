using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.RoomModels
{
    public class RoomUpdateRequestModel
    {
        [Required]
        public int Id { get; set; } // Güncellenecek odanın ID'si

        [Required]
        public string RoomNumber { get; set; }

        [Required]
        public int RoomTypeId { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }

        public string? Description { get; set; }
    }
}
