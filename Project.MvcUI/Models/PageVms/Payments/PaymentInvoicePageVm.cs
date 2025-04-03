using Project.Bll.DtoClasses;

namespace Project.MvcUI.Models.PageVms.Payments
{
    /// <summary>
    /// Ödeme fatura detaylarını View'da göstermek için kullanılan PageVM sınıfıdır.
    /// Rezervasyon, ödeme, oda ve ekstra hizmet bilgilerini içerir.
    /// </summary>
    public class PaymentInvoicePageVm
    {
        /// <summary>
        /// Rezervasyon bilgilerini taşıyan DTO.
        /// </summary>
        public ReservationDto Reservation { get; set; }

        /// <summary>
        /// Ödeme bilgilerini taşıyan DTO.
        /// </summary>
        public PaymentDto Payment { get; set; }

        /// <summary>
        /// Rezervasyona ait oda bilgilerini taşıyan DTO.
        /// </summary>
        public RoomDto Room { get; set; }

        /// <summary>
        /// Rezervasyona bağlı ekstra hizmetleri taşıyan DTO listesi.
        /// </summary>
        public List<ExtraServiceDto> ExtraServices { get; set; }

        /// <summary>
        /// Sayfa başlığı. View'da başlık olarak kullanılır.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Sayfada gösterilecek açıklayıcı yardım metni.
        /// </summary>
        public string HelpText { get; set; }

        /// <summary>
        /// Ödeme yapan kartın ilk 4 hanesini temsil eder.
        /// Mail veya fatura detaylarında maskeleme için kullanılır.
        /// </summary>
        public string CardNumber { get; set; }
    }
}
