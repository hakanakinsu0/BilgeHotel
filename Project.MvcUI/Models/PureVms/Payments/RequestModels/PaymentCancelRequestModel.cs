using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Payments.RequestModels
{
    /// <summary>
    /// Ödeme iptali işlemi için gerekli kullanıcıdan alınacak form verilerini temsil eden modeldir.
    /// Kart bilgileri, rezervasyon numarası ve iade edilecek tutar gibi alanları içerir.
    /// </summary>
    public class PaymentCancelRequestModel
    {
        /// <summary>
        /// İptal edilecek ödemenin ilişkili olduğu rezervasyonun ID'si.
        /// </summary>
        [Display(Name = "Rezervasyon Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public int ReservationId { get; set; }

        /// <summary>
        /// Kart sahibinin adı.
        /// </summary>
        [Display(Name = "Kart Sahibi")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CardUserName { get; set; }

        /// <summary>
        /// Kart numarası (tam veya maskelenmiş olarak).
        /// </summary>
        [Display(Name = "Kart Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string CardNumber { get; set; }

        /// <summary>
        /// Kartın arkasındaki 3 haneli güvenlik kodu.
        /// </summary>
        [Display(Name = "CVV")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV {0} 3 haneli olmalıdır.")]
        public string CVV { get; set; }

        /// <summary>
        /// Kullanıcıya iade edilecek tutar.
        /// </summary>
        [Display(Name = "İade Edilecek Tutar")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "{0} pozitif bir değer olmalıdır.")]
        public decimal RefundAmount { get; set; }

        /// <summary>
        /// İlgili rezervasyona ait oda numarası.
        /// </summary>
        [Display(Name = "Oda Numarası")]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public string RoomNumber { get; set; }

        /// <summary>
        /// Rezervasyonun başlangıç tarihi.
        /// </summary>
        [Display(Name = "Giriş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Rezervasyonun bitiş tarihi.
        /// </summary>
        [Display(Name = "Çıkış Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} gereklidir.")]
        public DateTime EndDate { get; set; }
    }
}
