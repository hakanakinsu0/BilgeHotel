using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.ReservationModels
{
    public class ReservationCancelRequestModel
    {
        [Required]
        public int Id { get; set; } // ✅ İptal edilecek rezervasyon ID
    }
}
