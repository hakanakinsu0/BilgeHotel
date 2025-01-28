using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Çalışanların detaylı bilgilerini temsil eder.
    /// Employee tablosu ile bire bir ilişkilidir.
    /// </summary>
    public class EmployeeDetail : BaseEntity
    {
        public string Address { get; set; } // Çalışanın adresi.
        public string PhoneNumber { get; set; } // Çalışanın telefon numarası.
        public decimal Salary { get; set; } // Çalışanın maaşı.
        public DateTime HireDate { get; set; } // Çalışanın işe giriş tarihi.
        public DateTime? BirthDate { get; set; } // Çalışanın doğum tarihi.

        // Foreign Keys
        public int EmployeeId { get; set; } // Çalışan ile ilişki için foreign key.

        // Relational Properties
        public virtual Employee Employee { get; set; } // Çalışan tablosu ile bire bir ilişki.
    }
}
