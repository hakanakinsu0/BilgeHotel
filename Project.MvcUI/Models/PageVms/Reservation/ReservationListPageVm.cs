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
        /// Constructor: Sayfa başlığı ve yardım metni varsayılan olarak tanımlanır.
        /// </summary>
        public ReservationListPageVm()
        {
            PageTitle = "Rezervasyonlarım";
            HelpText = "Aşağıda rezervasyon bilgileriniz görüntülenmektedir.";
        }

        /// <summary>
        /// Kullanıcının rezervasyon bilgilerini içerir.
        /// </summary>
        public IEnumerable<ReservationDto> Reservations { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Yardımcı metin (kullanıcıya ek bilgi vermek için).
        /// </summary>
        public string HelpText { get; set; }
    }
}
