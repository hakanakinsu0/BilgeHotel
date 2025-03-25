namespace Project.MvcUI.Models.PageVms.Reservations
{
    /// <summary>
    /// Rezervasyon iptali onay sayfası için kullanılan page model.
    /// Bu model; iptal edilecek rezervasyonun ID'sini, oda numarasını, sayfa başlığını ve yardımcı metni içerir.
    /// </summary>
    public class ReservationCancelPageVm
    {
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
        public string PageTitle { get; set; } = "Rezervasyon İptal Onayı";

        /// <summary>
        /// Kullanıcıya gösterilecek yardımcı metin.
        /// </summary>
        public string HelpText { get; set; } = "Lütfen rezervasyonu iptal etmek istediğinize emin olun.";
    }
}
