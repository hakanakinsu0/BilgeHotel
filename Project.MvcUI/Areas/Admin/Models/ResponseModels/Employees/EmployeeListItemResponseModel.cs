/// <summary>
/// Çalışan listeleme ekranında her bir satırı temsil eden response modelidir.
/// Temel kimlik, iletişim ve durum bilgilerini içerir.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees
{
    public class EmployeeListItemResponseModel
    {
        public int Id { get; set; } // Çalışan ID
        public string FirstName { get; set; } // Ad
        public string LastName { get; set; } // Soyad
        public string Position { get; set; } // Pozisyon
        public string PhoneNumber { get; set; } // Telefon numarası
        public string Status { get; set; } // Durum (Inserted, Updated, Deleted vb.)
    }
}
