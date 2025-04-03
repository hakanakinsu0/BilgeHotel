using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    public class PaymentCancelRequestModel
    {
        [Display(Name = "Rezervasyon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        [Display(Name = "Kart Sahibi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CardUserName { get; set; }

        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CardNumber { get; set; }

        [Display(Name = "CVV")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV {0} 3 haneli olmalıdır.")]
        public string CVV { get; set; }

        [Display(Name = "İade Edilecek Tutar")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "{0} pozitif bir değer olmalıdır.")]
        public decimal RefundAmount { get; set; }

        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string RoomNumber { get; set; }

        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime EndDate { get; set; }

    }
}
