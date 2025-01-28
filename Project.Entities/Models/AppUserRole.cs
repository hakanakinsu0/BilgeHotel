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
    /// Kullanıcılar ile roller arasındaki ilişkiyi temsil eder.
    /// AppUser ve AppRole tablolarını birbirine bağlayan junction table.
    /// </summary>
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }

        // Relational Properties
        public virtual AppUser User { get; set; } // İlişkili kullanıcı.
        public virtual AppRole Role { get; set; } // İlişkili rol.
    }
}
