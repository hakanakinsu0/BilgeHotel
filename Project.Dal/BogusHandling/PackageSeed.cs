using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    /// <summary>
    /// Sahte (fake) konaklama paketi verilerini oluşturur ve veritabanına ekler.
    /// Package tablosuna örnek paketleri eklemek için kullanılır.
    /// </summary>
    public static class PackageSeed
    {
        /// <summary>
        /// ModelBuilder kullanarak Package verilerini seed (ön yükleme) yapar.
        /// </summary>
        public static void SeedPackages(ModelBuilder modelBuilder)
        {
            // Otele ait konaklama paketleri tanımlanıyor.

            List<Package> packages = new()
            {
                new Package
                {
                    Id = 1,
                    Name = "Tam Pansiyon",          // Sabah, öğle ve akşam yemeği dahil olan paket
                    Description = "Kahvaltı, öğle ve akşam yemeği dahil.",
                    PriceMultiplier = 1.2m,         // Bu paket, temel fiyata %20 ekleme yapar
                    CreatedDate = DateTime.Now,     // Paketin oluşturulma zamanı
                    Status = DataStatus.Inserted    // Eklenmiş (Inserted) olarak işaretlendi
                },
                new Package
                {
                    Id = 2,
                    Name = "Her Şey Dahil",         // Tüm yemekler ve belirli hizmetler dahil
                    Description = "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.",
                    PriceMultiplier = 1.5m,         // Bu paket, temel fiyata %50 ekleme yapar
                    CreatedDate = DateTime.Now,     // Paketin oluşturulma zamanı
                    Status = DataStatus.Inserted    // Eklenmiş (Inserted) olarak işaretlendi
                }
            };

            // EF Core ile verileri veritabanına ekleme işlemi
            modelBuilder.Entity<Package>().HasData(packages);
        }
    }
}
