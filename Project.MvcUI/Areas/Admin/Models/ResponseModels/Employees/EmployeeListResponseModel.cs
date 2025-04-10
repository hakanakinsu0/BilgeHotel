/// <summary>
/// Çalışan listeleme ekranında sayfalama bilgileri ile birlikte gösterilecek çalışan listesini temsil eden modeldir.
/// </summary>
namespace Project.MvcUI.Areas.Admin.Models.ResponseModels.Employees
{
    public class EmployeeListResponseModel
    {
        public List<EmployeeListItemResponseModel> Employees { get; set; } // Çalışan listesi
        public int TotalPages { get; set; } // Toplam sayfa sayısı
        public int CurrentPage { get; set; } // Mevcut sayfa
        public int PageSize { get; set; } // Sayfa başına gösterilecek kayıt sayısı
    }
}
