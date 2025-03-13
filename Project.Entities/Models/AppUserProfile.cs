using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Kullanıcıların profil bilgilerini tutar.
    /// </summary>
    /// 
    public class AppUserProfile : BaseEntity
    {
        public string FirstName { get; set; }           // Kullanıcının adı.
        public string LastName { get; set; }            // Kullanıcının soyadı.
        public Gender Gender { get; set; }              // Kullanıcının cinsiyeti (ör. "Male", "Female").
        public string Address { get; set; }             // Kullanıcının adres bilgisi.
        public string? Nationality { get; set; }        // Kullanıcının uyruğu (isteğe bağlı).
        public string? IdentityNumber { get; set; }     // Kullanıcının kimlik veya pasaport numarası (isteğe bağlı).

        // Foreign Key
        public int AppUserId { get; set; }              // AppUserId, AppUser tablosundaki bir kullanıcıyı temsil eder ve profilin hangi kullanıcıya ait olduğunu belirler.

        // Relational Properties
        public virtual AppUser AppUser { get; set; }    // 1 AppUser 1 AppUserProfile, 1 AppUserProfile 1 AppUser
    }
}
