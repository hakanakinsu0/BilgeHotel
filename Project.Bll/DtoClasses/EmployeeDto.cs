using Project.Bll.DtoClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Çalışan verilerini taşımak için kullanılan DTO.
    /// Otelde çalışan kişileri temsil eder.
    /// </summary>
    public class EmployeeDto : BaseDto
    {
        public string FirstName { get; set; } // Çalışanın adı
        public string LastName { get; set; } // Çalışanın soyadı
        public string Position { get; set; } // Çalışanın pozisyonu
    }
}

