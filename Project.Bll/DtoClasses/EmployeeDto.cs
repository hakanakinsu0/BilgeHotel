using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// Çalışan verilerini taşımak için kullanılan DTO.
    /// Otelde çalışan kişilerin bilgilerini taşır.
    /// </summary>
    public class EmployeeDto : BaseDto
    {
        public string Position { get; set; }    // Çalışanın görev
        public string FirstName { get; set; }   // Çalışanın adı
        public string LastName { get; set; }    // Çalışanın soyadı
        public string PhoneNumber { get; set; } // Çalışanın iletişim numarası
        public string Address { get; set; }     // İkamet adresi
        public DateTime BirthDate { get; set; } // Doğum tarihi
        public ShiftType Shift { get; set; }    // ShiftType enum: Sabah, Akşam, Gece
        public decimal Salary { get; set; }     // Aylık maaş
        public DateTime HireDate { get; set; }  // İşe alınma tarihi
    }
}
