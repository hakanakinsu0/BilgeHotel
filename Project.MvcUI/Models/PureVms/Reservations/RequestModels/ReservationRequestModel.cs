using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Models.PureVms.Reservations.RequestModels
{
    public class ReservationRequestModel : IValidatableObject
    {
        [Required(ErrorMessage = "Giriş tarihi zorunludur.")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Çıkış tarihi zorunludur.")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Misafir sayısı zorunludur.")]
        [Range(1, 10, ErrorMessage = "Misafir sayısı 1 ile 10 arasında olmalıdır.")]
        public int GuestCount { get; set; }

        [Required(ErrorMessage = "Oda tipi seçilmelidir.")]
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "Ödeme yöntemi zorunludur.")]
        public int PaymentMethodId { get; set; }

        public string? SpecialRequests { get; set; } // Opsiyonel

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckOutDate <= CheckInDate)
            {
                yield return new ValidationResult("Çıkış tarihi, giriş tarihinden sonra olmalıdır.", new[] { "CheckOutDate" });
            }
        }
    }
}
