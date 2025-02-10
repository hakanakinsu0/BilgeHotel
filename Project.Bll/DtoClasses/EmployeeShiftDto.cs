using Project.Bll.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Çalışan ve vardiya ilişkisini taşımak için kullanılan DTO.
    /// Çalışanların hangi vardiyalarda çalıştığını temsil eder.
    /// </summary>
    public class EmployeeShiftDto : BaseDto
    {
        public int EmployeeId { get; set; } // Çalışanın ID'si
        public int ShiftId { get; set; } // Vardiyanın ID'si
        public string EmployeeName { get; set; } // Çalışanın adı ve soyadı
        public string ShiftName { get; set; } // Vardiyanın adı
    }
}
