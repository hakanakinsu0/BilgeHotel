using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Kullanıcı profil verilerini taşımak için kullanılan DTO.
    /// Sistemdeki kullanıcı profillerini temsil eder.
    /// </summary>
    public class AppUserProfileDto : BaseDto
    {
        public string FirstName { get; set; } // Kullanıcının adı
        public string LastName { get; set; } // Kullanıcının soyadı
        public DateTime? BirthDate { get; set; } // Kullanıcının doğum tarihi
        public Gender Gender { get; set; } // Kullanıcının cinsiyeti
        public int? AppUserId { get; set; } // Kullanıcının AppUser ile bağlantısı
    }
}
