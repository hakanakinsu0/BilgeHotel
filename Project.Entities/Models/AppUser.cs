using Microsoft.AspNetCore.Identity;
using Project.Entities.Enums;
using Project.Entities.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Sistemdeki kullanıcıları temsil eder.
    /// ASP.NET Identity'nin IdentityUser sınıfından türetilmiştir ve IEntity ile ortak özelliklere sahiptir.
    /// Kullanıcı profiline ait detaylar AppUserProfile tablosunda tutulacaktır.
    /// </summary>
    public class AppUser : IdentityUser<int>, IEntity
    {
        public Guid ActivationCode { get; set; } // Kullanıcının e-posta doğrulaması için benzersiz aktivasyon kodu.
        public DateTime CreatedDate { get; set; } // Kullanıcının sisteme eklendiği tarih.
        public DateTime? ModifiedDate { get; set; } // Kullanıcı bilgileri en son güncellendiği tarih. Null olabilir.
        public DateTime? DeletedDate { get; set; } // Kullanıcının silindiği tarih. Null olabilir.
        public DataStatus Status { get; set; } // Kullanıcının durumunu belirtir (Inserted, Updated, Deleted).

        // Relational Properties
        public virtual AppUserProfile AppUserProfile { get; set; } // 1 AppUser 1 AppUserProfile, 1 AppUserProfile 1 AppUser 
        public virtual ICollection<AppUserRole> UserRoles { get; set; } // Junction Table: 1 AppUser N AppRole, 1 AppRole N AppUser
        public virtual ICollection<Customer> Customers { get; set; } // 1 AppUser N Customer, 1 Customer 1 AppUser
    }
}
