using Project.WebApi.Models.Enums;

namespace Project.WebApi.Models.Entities
{
    /// <summary>
    /// Web API katmanındaki tüm varlık (entity) sınıfları için temel (base) özellikleri barındıran soyut sınıftır.
    /// Her entity sınıfı, bu sınıftan türeyerek; kimlik, tarihsel kayıt ve veri durumu takibi gibi ortak işlevleri devralır.
    /// </summary>
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;            // Nesne oluşturulduğunda varsayılan olarak şu anki tarih atanır.
            Status = DataStatus.Inserted;          // Yeni eklenen veri olarak varsayılan durum atanır.
        }

        public int Id { get; set; }                 // Birincil Anahtar (Primary Key)
        public DateTime CreatedDate { get; set; }   // Veri oluşturulma tarihi (otomatik atanır)
        public DateTime? ModifiedDate { get; set; } // Veri güncellenme tarihi (nullable, opsiyonel)
        public DateTime? DeletedDate { get; set; }  // Soft delete işlemleri için silinme tarihi (nullable)
        public DataStatus Status { get; set; }      // Verinin mevcut durumu (Inserted, Updated, Deleted)
    }
}
