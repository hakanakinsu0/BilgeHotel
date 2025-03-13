using Project.Entities.Enums;

namespace Project.MvcUI.Areas.Admin.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } // ✅ Kullanıcı Adı ve Soyadı
        public string Email { get; set; }
        public string Role { get; set; } // ✅ Kullanıcının Rolü (Admin, Üye vs.)
        public DataStatus Status { get; set; } // ✅ Kullanıcı Durumu (Aktif, Pasif)

        // ✅ Kullanıcı Profili ile ilgili alanlar
        public string Address { get; set; } // Kullanıcının Adresi
        public string Nationality { get; set; } // Kullanıcının Uyruğu
        public Gender Gender { get; set; } // Kullanıcının Cinsiyeti
        public string IdentityNumber { get; set; } // Kullanıcının Kimlik Numarası
    }
}
