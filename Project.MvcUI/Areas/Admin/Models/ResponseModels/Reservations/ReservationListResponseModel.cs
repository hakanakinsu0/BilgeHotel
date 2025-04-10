using Project.MvcUI.Areas.Admin.Models.RequestModels.Reservations;
using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels
{
    /// <summary>
    /// UI tarafında rezervasyon listeleme ekranı için kullanılan modeldir.
    /// Rezervasyon kayıtlarını, sayfalama bilgilerini ve mevcut filtreleme kriterlerini içerir.
    /// Listeleme işlemleri, filtre devamlılığı ve sayfa geçişleri için yardımcı olur.
    /// </summary>
    public class ReservationListResponseModel
    {
        /// <summary>
        /// Listeleme ekranında gösterilecek rezervasyon kayıtları
        /// </summary>
        public List<ReservationListRequestModel> Reservations { get; set; }

        /// <summary>
        /// Toplam sayfa sayısı (sayfalama için)
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Şu anda aktif olan sayfa numarası
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Sayfa başına gösterilecek kayıt sayısı
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Uygulanan arama filtresi (müşteri adı veya e-posta)
        /// </summary>
        public string Search { get; set; }

        /// <summary>
        /// Seçilen rezervasyon durumu filtresi
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Ödeme durumuna göre filtre (true: ödenmiş, false: bekliyor)
        /// </summary>
        public bool? IsPaid { get; set; }
    }
}
