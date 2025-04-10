using Project.Entities.Enums;

/// <summary>
/// Kullanıcı listelerinde veya detay görüntüleme sayfalarında gösterilecek temel kullanıcı bilgilerini taşıyan response modelidir.
/// </summary>
public class UserViewResponseModel
{
    public int Id { get; set; } // Kullanıcı ID'si
    public string FullName { get; set; } // Ad + Soyad
    public string Email { get; set; } // E-posta adresi
    public string Role { get; set; } // Rol adı (Admin, Member vb.)
    public DataStatus Status { get; set; } // Kullanıcının aktiflik durumu (Inserted, Updated, Deleted)
    public string Address { get; set; } // Adres bilgisi
    public string Nationality { get; set; } // Uyruğu
    public Gender Gender { get; set; } // Cinsiyet (Male, Female, Other)
    public string IdentityNumber { get; set; } // Kimlik / Pasaport numarası
}
