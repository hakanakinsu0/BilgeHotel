/// <summary>
/// Kullanıcı silme (pasif hale getirme) işleminde, silme onay ekranına gönderilen kullanıcı bilgilerini temsil eden modeldir.
/// Bu model, kullanıcının ID'si, adı, e-posta adresi ve rolünü içerir.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.AppUsers
{
    public class DeleteUserResponseModel
    {
        public int Id { get; set; } // Silinecek kullanıcının benzersiz ID'si
        public string FullName { get; set; } // Kullanıcının adı ve soyadı (birleştirilmiş halde)
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string Role { get; set; } // Kullanıcının sistemdeki rolü (Admin, Member vs.)
    }
}
