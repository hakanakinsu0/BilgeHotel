using Project.Bll.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Çalışan detay verilerini taşımak için kullanılan DTO.
    /// Otelde çalışan kişilere ait ek bilgileri temsil eder.
    /// </summary>
    public class EmployeeDetailDto : BaseDto
    {
        public string Address { get; set; } // Çalışanın adresi
        public string PhoneNumber { get; set; } // Çalışanın telefon numarası
        public decimal Salary { get; set; } // Çalışanın maaşı
        public DateTime HireDate { get; set; } // Çalışanın işe giriş tarihi
        public DateTime? BirthDate { get; set; } // Çalışanın doğum tarihi
        public int EmployeeId { get; set; } // Çalışan ile ilişki için foreign key
    }
}
