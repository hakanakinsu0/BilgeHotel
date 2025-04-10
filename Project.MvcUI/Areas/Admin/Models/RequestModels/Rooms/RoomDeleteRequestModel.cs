using Project.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Rooms
{
    /// <summary>
    /// Oda silme formunda kullanılan request model.
    /// Odaya ait temel bilgiler ve silinip silinemeyeceğine dair kontrol bilgisi içerir.
    /// </summary>
    public class RoomDeleteRequestModel
    {
        /// <summary>Silinmek istenen odanın veritabanı ID'si.</summary>
        [Display(Name = "Oda Numarası")]
        public int RoomId { get; set; }

        /// <summary>Odanın görüntülenecek numarası (örn: 101, 302...)</summary>
        [Display(Name = "Oda Numarası")]
        public string RoomNumber { get; set; }

        /// <summary>Odanın bulunduğu kat bilgisi.</summary>
        [Display(Name = "Kat")]
        public int Floor { get; set; }

        /// <summary>Odanın gecelik fiyatı.</summary>
        [Display(Name = "Gecelik Fiyat")]
        public decimal PricePerNight { get; set; }

        /// <summary>Odanın ait olduğu oda tipi adı (örn: Tek Kişilik).</summary>
        [Display(Name = "Oda Tipi")]
        public string RoomTypeName { get; set; }

        /// <summary>Odanın mevcut durumu (Boş, Dolu, Bakımda).</summary>
        [Display(Name = "Oda Durumu")]
        public RoomStatus RoomStatus { get; set; }

        /// <summary>Odanın aktif bir rezervasyona sahip olup olmadığını belirten bilgi.</summary>
        [Display(Name = "Aktif Rezervasyon Var mı?")]
        public bool HasActiveReservations { get; set; }
    }
}
