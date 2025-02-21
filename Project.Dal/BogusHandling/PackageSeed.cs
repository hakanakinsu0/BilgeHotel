using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    public static class PackageSeed
    {
        public static void SeedPackages(ModelBuilder modelBuilder)
        {
            List<Package> packages = new()
            {
                new Package
                {
                    Id = 1,
                    Name = "Tam Pansiyon",
                    Description = "Kahvaltı, öğle ve akşam yemeği dahil.",
                    PriceMultiplier = 1.2m,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },
                new Package
                {
                    Id = 2,
                    Name = "Her Şey Dahil",
                    Description = "Tüm yemekler, alkollü-alkolsüz içecekler ve otelin sunduğu belirli hizmetler dahil.",
                    PriceMultiplier = 1.5m,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                }
            };

            modelBuilder.Entity<Package>().HasData(packages);
        }
    }
}
