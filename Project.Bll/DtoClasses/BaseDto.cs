using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Tüm DTO'lar için temel sınıf.
    /// Ortak özellikleri içerir ve veri taşımayı kolaylaştırır.
    /// </summary>
    public abstract class BaseDto
    {
        public int Id { get; set; }                 // Benzersiz kimlik numarası (Primary Key).
        public DateTime CreatedDate { get; set; }   // Verinin oluşturulma tarihi.
        public DateTime? ModifiedDate { get; set; } // Verinin güncellenme tarihi. Null olabilir.
        public DateTime? DeletedDate { get; set; }  // Verinin silindiği tarih. Null olabilir.
        public DataStatus Status { get; set; }      // Verinin mevcut durumu (Inserted, Updated, Deleted).
    }
}