using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Otelde çalışan kişileri temsil eder.
    /// Vardiyalar ve detay bilgilerle ilişkilidir.
    /// </summary>
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } // Çalışanın adı.
        public string LastName { get; set; } // Çalışanın soyadı.
        public string Position { get; set; } // Çalışanın pozisyonu (ör. "Resepsiyonist").

        // Relational Properties
        public virtual EmployeeDetail EmployeeDetail { get; set; } // Çalışanın detay bilgileri ile bire bir ilişki.
        public virtual IQueryable<EmployeeShift> EmployeeShifts { get; set; } // Çalışanın vardiya ilişkisi.
    }
}
