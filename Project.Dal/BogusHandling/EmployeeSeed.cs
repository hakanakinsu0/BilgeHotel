using Bogus;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    public static class EmployeeSeed
    {
        public static void SeedEmployees(ModelBuilder modelBuilder)
        {
            var faker = new Faker("tr"); // Türkçe dil desteği eklendi
            List<Employee> employees = new();

            int employeeId = 1;

            // **Pozisyonlara göre çalışanları ekleyelim**
            var positions = new Dictionary<string, (int count, decimal minRate, decimal maxRate, bool hasNightShift)>
            {
                { "Resepsiyonist", (7, 120, 160, true) },
                { "Temizlik Görevlisi", (11, 110, 140, false) },
                { "Aşçı", (11, 130, 170, false) },
                { "Garson", (13, 100, 140, false) },
                { "Elektrikçi", (1, 140, 180, true) },
                { "IT Sorumlusu", (1, 150, 190, true) }
            };

            foreach (var position in positions)
            {
                for (int i = 0; i < position.Value.count; i++)
                {
                    var firstName = faker.Name.FirstName();
                    var lastName = faker.Name.LastName();
                    var shiftType = position.Value.hasNightShift
                        ? faker.PickRandom<ShiftType>() // Eğer gece vardiyası varsa rastgele seç
                        : faker.PickRandom(new List<ShiftType> { ShiftType.Morning, ShiftType.Evening }); // Sadece sabah ve akşam vardiyası seç
                    var hourlyRate = faker.Finance.Amount(position.Value.minRate, position.Value.maxRate, 2);

                    employees.Add(new Employee
                    {
                        Id = employeeId,
                        FirstName = firstName,
                        LastName = lastName,
                        Address = faker.Address.FullAddress(), // Tam adres bilgisi
                        PhoneNumber = faker.Phone.PhoneNumber(), // Telefon numarası
                        Salary = hourlyRate, // Saatlik ücret
                        Shift = shiftType, // Çalışma vardiyası
                        HireDate = faker.Date.Past(10, DateTime.Now.AddYears(-1)), // 1 yıldan fazla süredir çalışanlar
                        BirthDate = faker.Date.Past(40, DateTime.Now.AddYears(-18)), // 18 yaşından büyükler
                        CreatedDate = DateTime.Now,
                        Status = DataStatus.Inserted
                    });

                    employeeId++;
                }
            }

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
