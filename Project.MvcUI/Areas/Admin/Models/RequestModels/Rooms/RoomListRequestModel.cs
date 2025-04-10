namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    /// <summary>
    /// Oda listeleme sayfasında filtreleme işlemleri için kullanılan istek modelidir.
    /// </summary>
    public class RoomListRequestModel
    {
        /// <summary>Seçilen oda türünün ID'si (örn: Tek Kişilik = 1).</summary>
        public int? RoomTypeId { get; set; }

        /// <summary>Oda durumu: "Empty", "Occupied", "Maintenance" gibi değerler alabilir.</summary>
        public string Status { get; set; }

        /// <summary>Kat bilgisi (örn: 1. Kat, 2. Kat...).</summary>
        public int? Floor { get; set; }

        /// <summary>Listeleme için alt fiyat sınırı.</summary>
        public decimal? MinPrice { get; set; }

        /// <summary>Listeleme için üst fiyat sınırı.</summary>
        public decimal? MaxPrice { get; set; }

        /// <summary>Oda rezerve edilmiş mi? (true: rezerve, false: boş, null: tümü).</summary>
        public bool? HasReservation { get; set; }
    }
}
