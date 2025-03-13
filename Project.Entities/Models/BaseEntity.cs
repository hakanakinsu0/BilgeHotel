using Project.Entities.Enums;
using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Tüm entity sınıflarının ortak özelliklerini içeren temel (base) bir abstract sınıftır.
    /// Kod tekrarı yapmadan ortak özelliklerin tüm entity sınıflarında kullanılmasını sağlamak.
    /// </summary>
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }                 // Veritabanı tablolarında birincil anahtar (Primary Key) olarak kullanılır.
        public DateTime CreatedDate { get; set; }   // Verinin oluşturulduğu tarih.
        public DateTime? ModifiedDate { get; set; } // Verinin en son güncellendiği tarih. Null olabilir.
        public DateTime? DeletedDate { get; set; }  // Verinin silindiği tarih. Null olabilir.
        public DataStatus Status { get; set; }      // Verinin durumunu (Inserted, Updated, Deleted) belirler.
    }
}
