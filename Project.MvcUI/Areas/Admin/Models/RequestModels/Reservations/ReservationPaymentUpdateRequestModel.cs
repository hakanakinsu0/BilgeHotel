using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    /// <summary>
    /// Rezervasyon ödeme durumu güncelleme işlemleri için kullanılan model.
    /// Müşteri bilgileri, mevcut durum ve seçilecek yeni durum gibi alanları içerir.
    /// </summary>
    public class ReservationPaymentUpdateRequestModel
    {
        /// <summary>Güncellenecek rezervasyonun ID bilgisi.</summary>
        [Display(Name = "Rezervasyon ID")]
        public int ReservationId { get; set; }

        /// <summary>Müşteri adı (sadece görüntülenir).</summary>
        [Display(Name = "Müşteri Adı")]
        public string CustomerName { get; set; }

        /// <summary>Oda numarası (sadece görüntülenir).</summary>
        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; }

        /// <summary>Yeni seçilecek ödeme durumu.</summary>
        [Display(Name = "Yeni Ödeme Durumu")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public ReservationStatus NewStatus { get; set; }

        /// <summary>Mevcut rezervasyon durumu (sadece gösterim amacıyla).</summary>
        [Display(Name = "Mevcut Durum")]
        public ReservationStatus CurrentStatus { get; set; }
    }
}
