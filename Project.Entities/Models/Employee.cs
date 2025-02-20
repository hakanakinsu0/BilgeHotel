using Project.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Project.Entities.Models
{
    /// <summary>
    /// Otelde çalışan kişileri temsil eder.
    /// </summary>
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; } // Çalışanın adı.
        public string LastName { get; set; } // Çalışanın soyadı.
        public string Address { get; set; } // Çalışanın adresi.
        public string PhoneNumber { get; set; } // Çalışanın telefon numarası.
        public decimal Salary { get; set; } // Çalışanın maaşı.
        public DateTime HireDate { get; set; } // Çalışanın işe giriş tarihi.
        public DateTime? BirthDate { get; set; } // Çalışanın doğum tarihi.
        public ShiftType Shift { get; set; } // Sabah / Akşam / Gece vardiyası.

        // Rezervasyonlarla ilişkilendirildi
        public virtual ICollection<Reservation> ManagedReservations { get; set; } // 1 Employee N Reservation
    }
}
