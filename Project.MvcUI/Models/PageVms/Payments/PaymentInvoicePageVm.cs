using Project.Bll.DtoClasses;

namespace Project.MvcUI.Models.PageVms.Payments
{
    public class PaymentInvoicePageVm
    {
        // Mevcut DTO'ları entegre ediyoruz:
        public ReservationDto Reservation { get; set; }  // Rezervasyon bilgileri
        public PaymentDto Payment { get; set; }          // Ödeme bilgileri
        public RoomDto Room { get; set; }                // Oda bilgileri

        // Rezervasyona ait ekstra servis bilgileri, mevcut ExtraServiceDto kullanılarak tutuluyor.
        public List<ExtraServiceDto> ExtraServices { get; set; } = new List<ExtraServiceDto>();

        // UI'ya özgü ek bilgiler:
        public string PageTitle { get; set; }
        public string HelpText { get; set; }


    }
}
