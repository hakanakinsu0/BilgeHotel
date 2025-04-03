using Project.Bll.DtoClasses;
using Project.Entities.Enums;
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
        public string Position { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public ShiftType Shift { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

    }
}

