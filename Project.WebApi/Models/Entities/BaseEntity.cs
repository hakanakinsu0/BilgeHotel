using Project.WebApi.Models.Enums;

namespace Project.WebApi.Models.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }

        public int Id { get; set; }  // Birincil Anahtar (Primary Key)
        public DateTime CreatedDate { get; set; }  // Veri ekleme tarihi
        public DateTime? ModifiedDate { get; set; }  // Güncellenme tarihi
        public DateTime? DeletedDate { get; set; }  // Silinme tarihi (Soft Delete için)
        public DataStatus Status { get; set; }  // Veri durumu
    }
}
