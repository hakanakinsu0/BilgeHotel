using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Vardiya verilerini taşımak için kullanılan DTO.
    /// Çalışanların vardiya bilgilerini temsil eder.
    /// </summary>
    public class ShiftDto : BaseDto
    {
        public string ShiftName { get; set; } // Vardiya adı (ör. "Sabah", "Akşam", "Gece")
        public TimeSpan StartTime { get; set; } // Vardiya başlangıç saati
        public TimeSpan EndTime { get; set; } // Vardiya bitiş saati
    }
}
