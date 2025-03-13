using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Entities.Enums
{
    /// <summary>
    /// Çalışma vardiyalarını temsil eder.
    /// </summary>
    public enum ShiftType
    {
        Morning = 1,  // Sabah (08:00 - 16:00)
        Evening = 2,  // Akşam (16:00 - 00:00)
        Night = 3     // Gece (00:00 - 08:00)
    }
}

