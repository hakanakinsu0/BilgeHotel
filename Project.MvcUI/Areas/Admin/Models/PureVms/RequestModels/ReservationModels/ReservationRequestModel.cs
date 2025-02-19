using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.RezervationModels
{
    public class ReservationRequestModel
    {
        [Required]
        public int RoomId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public string? Notes { get; set; }
    }
}
