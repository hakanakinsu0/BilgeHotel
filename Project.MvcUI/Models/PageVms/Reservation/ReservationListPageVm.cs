using System.Collections.Generic;
using Project.Bll.DtoClasses;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Kullanıcının rezervasyon listesini görüntülemek için kullanılan page model.
    /// Rezervasyon bilgileri, sayfa başlığı ve yardımcı metin içerir.
    /// </summary>
    public class ReservationListPageVm
    {
        /// <summary>
        /// Kullanıcının rezervasyon bilgilerini içerir.
        /// </summary>
        public IEnumerable<ReservationDto> Reservations { get; set; } = new List<ReservationDto>();

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; } = "Rezervasyonlarım";

        /// <summary>
        /// Yardımcı metin (kullanıcıya ek bilgi vermek için).
        /// </summary>
        public string HelpText { get; set; } = "Aşağıda rezervasyon bilgileriniz görüntülenmektedir.";
    }
}
