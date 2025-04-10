using System.Collections.Generic;

namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Rooms
{
    /// <summary>
    /// UI'da oda listeleme sayfasında kullanılan response modelidir.
    /// Sayfalama bilgileri ve listelenecek odaların detaylarını içerir.
    /// </summary>
    public class RoomListResponseModel
    {
        /// <summary>
        /// Oda listesinde gösterilecek satır verilerini tutar.
        /// </summary>
        public List<RoomListItemResponseModel> Rooms { get; set; } = new List<RoomListItemResponseModel>();

        /// <summary>
        /// Toplam sayfa sayısı (sayfalama için)
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Mevcut sayfa numarası (aktif sayfa)
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Sayfa başına gösterilecek kayıt sayısı
        /// </summary>
        public int PageSize { get; set; }
    }
}
