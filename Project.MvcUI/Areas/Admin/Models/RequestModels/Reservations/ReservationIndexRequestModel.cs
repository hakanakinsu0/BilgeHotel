using System;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations
{
    public class ReservationIndexRequestModel
    {
        public string Search { get; set; }          // Müşteri adı veya e-posta
        public int? RoomId { get; set; }            // Oda ID (numarasına göre filtre)
        public string Status { get; set; }          // Rezervasyon durumu
        public bool? IsPaid { get; set; }           // Ödeme durumu (true/false/null)
    }
}
