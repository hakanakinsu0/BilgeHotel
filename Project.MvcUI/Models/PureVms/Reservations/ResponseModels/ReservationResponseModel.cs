namespace Project.MvcUI.Models.PureVms.Reservations.ResponseModels
{
    public class ReservationResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? ReservationId { get; set; } // Başarılı rezervasyonun ID'si
        public DateTime? ReservationDate { get; set; } // Rezervasyonun oluşturulma tarihi
    }
}
