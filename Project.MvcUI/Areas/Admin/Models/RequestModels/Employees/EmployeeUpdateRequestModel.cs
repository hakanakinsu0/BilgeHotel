using System.ComponentModel.DataAnnotations;

namespace Project.MvcUI.Areas.Admin.Models.RequestModels.Employees
{
    public class EmployeeUpdateRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Pozisyon bilgisi zorunludur.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Maaş bilgisi zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Geçerli bir maaş giriniz.")]
        public decimal Salary { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
