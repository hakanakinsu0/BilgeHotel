using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Kullanıcıların profil bilgilerini tutar.
    /// AppUser ile bire bir ilişkilidir.
    /// </summary>
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; } // Kullanıcının adı.
        public string LastName { get; set; } // Kullanıcının soyadı.
        public DateTime? BirthDate { get; set; } // Kullanıcının doğum tarihi. Null olabilir.
        public string Gender { get; set; } // Kullanıcının cinsiyeti (ör. "Male", "Female").

        //Foreign Keys
        public int? AppUserId { get; set; } // AppUser ile bire bir ilişki için kullanılan yabancı anahtar (Foreign Key).
        // AppUserId: Bu alan, AppUser tablosundaki bir kullanıcıyı temsil eder.
        // Bire bir ilişkiyi yönetmek için gerekli olup, AppUser ile ilişkili profil verisinin kolayca eşleştirilmesini sağlar.


        // Relational Property
        public virtual AppUser AppUser { get; set; } // AppUser ile bire bir ilişki.
    }
}
