/// <summary>
/// Çalışan silme işlemi öncesinde, çalışan bilgilerini onay ekranına taşımak için kullanılan response modelidir.
/// Sadece temel kimlik ve iletişim bilgilerini içerir.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees
{
    public class EmployeeDeleteResponseModel
    {
        public int Id { get; set; } // Çalışan ID
        public string FirstName { get; set; } // Ad
        public string LastName { get; set; } // Soyad
        public string Position { get; set; } // Pozisyon
        public string PhoneNumber { get; set; } // Telefon numarası
    }
}
