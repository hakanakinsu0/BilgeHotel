using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Employees
{
    public class EmployeeUpdateRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} bilgisi zorunludur.")]
        [Display(Name = "Pozisyon")]
        public string Position { get; set; }

        [Required(ErrorMessage = "{0} gereklidir.")]
        [RegularExpression(@"^05\d{9}$", ErrorMessage = "{0} 05 ile başlayan 11 haneli olmalıdır.")]
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} bilgisi zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Geçerli bir {0} giriniz.")]
        [Display(Name = "Maaş")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "{0} bilgisi zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }
    }
}
