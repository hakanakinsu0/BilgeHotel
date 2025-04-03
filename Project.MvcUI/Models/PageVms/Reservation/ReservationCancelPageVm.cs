namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon iptali onay sayfası için kullanılan page model.
    /// Bu model; iptal edilecek rezervasyonun ID'sini, oda numarasını, sayfa başlığını ve yardımcı metni içerir.
    /// </summary>
    public class ReservationCancelPageVm
    {
        /// <summary>
        /// Constructor: Sayfa başlığı ve yardım metni varsayılan olarak tanımlanır.
        /// </summary>
        public ReservationCancelPageVm()
        {
            PageTitle = "Rezervasyon İptal Onayı";
            HelpText = "Lütfen rezervasyonu iptal etmek istediğinize emin olun.";
        }

        /// <summary>
        /// İptal edilecek rezervasyonun ID'si.
        /// </summary>
        public int ReservationId { get; set; }

        /// <summary>
        /// Rezervasyonla ilişkili oda numarası.
        /// </summary>
        public string RoomNumber { get; set; }

        /// <summary>
        /// Sayfa başlığı.
        /// </summary>
        public string PageTitle { get; set; }

        /// <summary>
        /// Kullanıcıya gösterilecek yardımcı metin.
        /// </summary>
        public string HelpText { get; set; }
    }
}
