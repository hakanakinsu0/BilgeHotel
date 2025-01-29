using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Çalışanlar ile vardiyalar arasındaki ilişkiyi temsil eder.
    /// Employee ve Shift tablolarını birbirine bağlayan junction table.
    /// </summary>
    public class EmployeeShift : BaseEntity
    {
        // Foreign Keys
        public int EmployeeId { get; set; } // Çalışanı temsil eder.
        public int ShiftId { get; set; } // Vardiyayı temsil eder.

        // Relational Properties
        public virtual Employee Employee { get; set; } // 1 Employee N Shift, 1 Shift N Employee
        public virtual Shift Shift { get; set; } // 1 Employee N Shift, 1 Shift N Employee

    }
}
