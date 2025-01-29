using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Çalışanların vardiya bilgilerini temsil eder.
    /// Vardiyalar ile çalışanlar arasında ilişki kurar.
    /// </summary>
    public class Shift : BaseEntity
    {
        public string ShiftName { get; set; } // Vardiya adı (ör. "Sabah", "Akşam", "Gece").
        public TimeSpan StartTime { get; set; } // Vardiya başlangıç saati.
        public TimeSpan EndTime { get; set; } // Vardiya bitiş saati.

        // Relational Properties
        public virtual ICollection<EmployeeShift> EmployeeShifts { get; set; } // 1 Employee N Shift, 1 Shift N Employee
    }
}
