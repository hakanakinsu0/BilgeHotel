using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.PureVms.RequestModels.RezervationModels
{
    public class ReservationCancelRequestModel
    {
        [Required]
        public int Id { get; set; } // İptal edilecek rezervasyonun ID'si

        [Required]
        public string CancelReason { get; set; } // İptal sebebi

        public bool RefundRequested { get; set; } // Ödeme iadesi talep edildi mi?
    }
}
