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
        public string Position { get; set; } // Çalışanın pozisyonu.

        // Relational Properties
        public virtual EmployeeDetail EmployeeDetail { get; set; } // 1 Employee 1 EmployeeDetail, 1 EmployeeDetail 1 Employee
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; } // 1 Employee N Shift, 1 Shift N Employee
        public virtual ICollection<Reservation> ManagedReservations { get; set; } // 1 Employee N Reservation, 1 Reservation 1 Employee
    }
}
