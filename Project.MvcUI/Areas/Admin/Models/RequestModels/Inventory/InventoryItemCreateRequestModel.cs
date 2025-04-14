using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Inventory
{
    /// <summary>
    /// Yeni donanım ekleme işlemi sırasında kullanılan model.
    /// </summary>
    public class InventoryItemCreateRequestModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [Display(Name = "Cihaz Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Seri numarası zorunludur.")]
        [Display(Name = "Seri Numarası")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Konum bilgisi zorunludur.")]
        [Display(Name = "Konum")]
        public string Location { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Kategori bilgisi zorunludur.")]
        [Display(Name = "Kategori")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Sorumlu personel seçilmelidir.")]
        [Display(Name = "Sorumlu (Çalışan)")]
        public int EmployeeId { get; set; }
    }
}
