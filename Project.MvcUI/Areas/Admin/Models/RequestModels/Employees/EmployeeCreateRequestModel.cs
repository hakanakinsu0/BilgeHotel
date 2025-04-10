using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Employees
{
    // <summary>
    /// Yeni bir çalışan oluşturmak için kullanılan request modelidir.
    /// Kullanıcıdan alınan form verilerini taşır ve validasyon kurallarını içerir.
    /// </summary>
    public class EmployeeCreateRequestModel
    {
        // Çalışanın adı
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        // Çalışanın soyadı
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        // Görev/pozisyon bilgisi
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Pozisyon")]
        public string Position { get; set; }

        // Telefon numarası, 05 ile başlayan ve 11 haneli olmalı
        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Telefon Numarası")]
        [RegularExpression(@"^05\d{9}$", ErrorMessage = "{0} 05 ile başlamalı ve 11 haneli olmalıdır.")]
        public string PhoneNumber { get; set; }

        // Adres bilgisi
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        // Doğum tarihi, tip kontrolü date
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        // Maaş bilgisi (0'dan küçük olamaz)
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Maaş")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        public decimal Salary { get; set; }
    }

}
