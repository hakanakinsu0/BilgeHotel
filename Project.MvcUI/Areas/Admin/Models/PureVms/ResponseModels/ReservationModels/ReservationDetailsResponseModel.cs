namespace Project.MvcUI.Areas.Admin.Models.PureVms.ResponseModels
{
    public class ReservationDetailsResponseModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string RoomName { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } // Aktif / İptal Edildi
        public string? Notes { get; set; }
    }
}
