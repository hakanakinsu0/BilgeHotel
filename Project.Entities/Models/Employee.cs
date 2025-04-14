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
        public string FirstName { get; set; }       // Çalışanın adı.
        public string LastName { get; set; }        // Çalışanın soyadı.
        public string Position { get; set; }        // Çalışanın görevi (Örn: Resepsiyonist, Aşçı, Garson, Temizlik Görevlisi).
        public string Address { get; set; }         // Çalışanın adresi.
        public string PhoneNumber { get; set; }     // Çalışanın telefon numarası.
        public decimal Salary { get; set; }         // Çalışanın maaşı.
        public DateTime HireDate { get; set; }      // Çalışanın işe giriş tarihi.
        public DateTime? BirthDate { get; set; }    // Çalışanın doğum tarihi.
        public ShiftType Shift { get; set; }        // Çalışanın mevcut vardiyası (Sabah, Akşam veya Gece).

        // Relational Properties
        public virtual ICollection<Reservation> ManagedReservations { get; set; } // 1 Employee N Reservation, 1 Reservation 1 Employee (Bir rezervasyon yonetiminde bir çalısan olur)
        public virtual ICollection<InventoryItem> InventoryItems { get; set; } // 1 Employee N InventoryItem, 1 InventoryItem 1 Employee

    }
}
