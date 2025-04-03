using Bogus;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    /// Sahte (fake) çalışan verileri oluşturur ve veritabanına ekler.
    /// Faker kütüphanesi kullanılarak rastgele çalışanlar oluşturulur.
    public static class EmployeeSeed
    {
        /// <summary>
        /// ModelBuilder kullanarak çalışan verilerini seed (ön yükleme) yapar.
        /// </summary>
        public static void SeedEmployees(ModelBuilder modelBuilder)
        {
            Faker faker = new Faker("tr");      // Türkçe dil desteği ile rastgele veri üret
            List<Employee> employees = new();   // Çalışan listesi

            int employeeId = 1; // Çalışan ID başlangıç değeri

            // Pozisyonlara göre çalışanların eklenmesi
            var positions = new Dictionary<string, (int count, decimal minRate, decimal maxRate, bool hasNightShift)>
            {
                { "Resepsiyonist", (7, 40000, 60000, true) },
                { "Temizlik Görevlisi", (11, 25000, 35000, false) },
                { "Aşçı", (11, 100000, 120000, false) },
                { "Garson", (13, 70000, 100000, false) },
                { "Elektrikçi", (1, 110000, 180000, true) },
                { "IT Sorumlusu", (1, 150000, 190000, true) }
            };

            foreach (var position in positions) // Her pozisyon için çalışan ekle
            {
                for (int i = 0; i < position.Value.count; i++)  // Belirtilen sayıda çalışan oluştur
                {
                    string firstName = faker.Name.FirstName();  // Rastgele isim
                    string lastName = faker.Name.LastName();    // Rastgele soyisim

                    ShiftType shiftType = position.Value.hasNightShift
                        ? faker.PickRandom<ShiftType>()         // Rastgele vardiya seç
                        : faker.PickRandom(new List<ShiftType> { ShiftType.Morning, ShiftType.Evening });           // Sadece sabah ve akşam vardiyası seç

                    decimal monthlyRate = faker.Finance.Amount(position.Value.minRate, position.Value.maxRate, 2);  // Maaşı belirle

                    employees.Add(new Employee
                    {
                        Id = employeeId,            //Primary Key
                        FirstName = firstName,      // Adı
                        LastName = lastName,        // Soyadı
                        Position = position.Key,    // Çalışanın görevi
                        Address = faker.Address.FullAddress(),      // Tam adres bilgisi
                        PhoneNumber = "+90" + faker.Random.Replace("5#########"), // Telefon numarası
                        Salary = monthlyRate,       // Aylik ücret
                        Shift = shiftType,          // Çalışma vardiyası
                        HireDate = faker.Date.Past(10, DateTime.Now.AddYears(-1)),      // 1 yıldan fazla süredir çalışanlar, en fazla 10 yıl önce işe başlamış olabilir
                        BirthDate = faker.Date.Past(40, DateTime.Now.AddYears(-18)),    // 18 ile 58 yaş arasında olmalı (58 = 18 + 40)
                        CreatedDate = DateTime.Now,     // Çalışan oluşturulma zamanı
                        Status = DataStatus.Inserted    // Varsayılan olarak "Inserted" (Eklenmiş) durumu atanıyor
                    });

                    employeeId++; //Primary Key'i 1 arttir.
                }
            }

            modelBuilder.Entity<Employee>().HasData(employees); // Çalışanları EF Core ile seed et
        }
    }
}
