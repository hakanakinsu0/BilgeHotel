using Project.Entities.Enums;

public class UserViewResponseModel
{
    public int Id { get; set; }
    public string FullName { get; set; } // Kullanıcı Adı ve Soyadı
    public string Email { get; set; }
    public string Role { get; set; }
    public DataStatus Status { get; set; }

    // Profil ile ilgili alanlar
    public string Address { get; set; }
    public string Nationality { get; set; }
    public Gender Gender { get; set; }
    public string IdentityNumber { get; set; }
}
