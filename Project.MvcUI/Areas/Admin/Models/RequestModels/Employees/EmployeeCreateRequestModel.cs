using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Employees
{
    public class EmployeeCreateRequestModel
    {
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Pozisyon")]
        public string Position { get; set; }

        [Required(ErrorMessage = "{0} zorunludur.")]
        [Display(Name = "Telefon Numarası")]
        [RegularExpression(@"^05\d{9}$", ErrorMessage = "{0} 05 ile başlamalı ve 11 haneli olmalıdır.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [Display(Name = "Maaş")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} negatif olamaz.")]
        public decimal Salary { get; set; }
    }
}
