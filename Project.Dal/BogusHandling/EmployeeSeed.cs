using Bogus;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.BogusHandling
{
    public static class EmployeeSeed
    {
        public static void SeedEmployees(ModelBuilder modelBuilder)
        {
            var faker = new Faker("tr"); // Türkçe dil desteği eklendi
            List<Employee> employees = new();
            List<EmployeeDetail> employeeDetails = new();

            int employeeId = 1;

            // **Pozisyonlara göre çalışanları ekleyelim**
            var positions = new Dictionary<string, int>
            {
                { "Resepsiyonist", 7 },
                { "Temizlik Görevlisi", 11 },
                { "Aşçı", 11 },
                { "Garson", 13 },
                { "Elektrikçi", 1 },
                { "IT Sorumlusu", 1 }
            };

            foreach (var position in positions)
            {
                for (int i = 0; i < position.Value; i++)
                {
                    var firstName = faker.Name.FirstName();
                    var lastName = faker.Name.LastName();

                    employees.Add(new Employee
                    {
                        Id = employeeId,
                        FirstName = firstName,
                        LastName = lastName,
                        Position = position.Key,
                        CreatedDate = DateTime.Now,
                        Status = DataStatus.Inserted
                    });

                    employeeDetails.Add(new EmployeeDetail
                    {
                        Id = employeeId,
                        EmployeeId = employeeId,
                        Address = faker.Address.FullAddress(), // Tam adres bilgisi
                        PhoneNumber = faker.Phone.PhoneNumber(), // Telefon numarası
                        Salary = faker.Finance.Amount(15000, 50000, 2), // 15.000 - 50.000 TL arası maaş
                        BirthDate = faker.Date.Past(40, DateTime.Now.AddYears(-18)), // 18 yaşından büyük
                        HireDate = faker.Date.Past(10, DateTime.Now.AddYears(-1)),// 1 yıldan fazla süredir çalışan
                        CreatedDate = DateTime.Now,
                        Status = DataStatus.Inserted
                    });

                    employeeId++;
                }
            }

            modelBuilder.Entity<Employee>().HasData(employees);
            modelBuilder.Entity<EmployeeDetail>().HasData(employeeDetails);
        }
    }
}