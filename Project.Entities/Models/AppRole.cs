using Microsoft.AspNetCore.Identity;
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
    /// Sistemdeki kullanıcı rollerini temsil eder. 
    /// ASP.NET Identity'nin IdentityRole sınıfından türetilmiştir ve IEntity ile ortak özelliklere sahiptir.
    /// 
    /// IdentityRole<int>: Identity kütüphanesi varsayılan olarak `string` tipinde bir Id kullanır. 
    /// Ancak projede Id alanı için `int` tipi tercih edildiği için bu generic yapı kullanılmıştır.
    /// </summary>
    public class AppRole : IdentityRole<int>, IEntity
    {
        public DateTime CreatedDate { get; set; } // Rolün oluşturulduğu tarih.
        public DateTime? ModifiedDate { get; set; } // Rolün güncellendiği tarih. Null olabilir.
        public DateTime? DeletedDate { get; set; } // Rolün silindiği tarih. Null olabilir.
        public DataStatus Status { get; set; } // Verinin durumunu belirtir (Inserted, Updated, Deleted).

        //Relational Properties
        public virtual ICollection<AppUserRole> UserRoles { get; set; } // Çoktan çoğa ilişki.

    }
}
