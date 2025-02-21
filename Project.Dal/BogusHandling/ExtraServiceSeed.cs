using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    public static class ExtraServiceSeed
    {
        public static void SeedExtraServices(ModelBuilder modelBuilder)
        {
            List<ExtraService> extraServices = new()
            {
                new ExtraService { Id = 1, Name = "Spa Kullanımı", Description = "Günlük sınırsız spa kullanımı.", Price = 50, CreatedDate = DateTime.Now, Status = DataStatus.Inserted },
                new ExtraService { Id = 2, Name = "Oda Servisi", Description = "24 saat oda servisi. Tüm yemek siparişleri dahildir.", Price = 30, CreatedDate = DateTime.Now, Status = DataStatus.Inserted },
                new ExtraService { Id = 3, Name = "Minibar Kullanımı", Description = "Minibardaki içecekler ve atıştırmalıklar dahil.", Price = 20, CreatedDate = DateTime.Now, Status = DataStatus.Inserted },
                new ExtraService { Id = 4, Name = "Havalimanı Transferi", Description = "Gidiş-dönüş özel araç transferi.", Price = 100, CreatedDate = DateTime.Now, Status = DataStatus.Inserted },
                new ExtraService { Id = 5, Name = "Çamaşırhane Hizmeti", Description = "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", Price = 40, CreatedDate = DateTime.Now, Status = DataStatus.Inserted },
                new ExtraService { Id = 6, Name = "Günlük Oda Temizliği", Description = "Ekstra günlük temizlik ve hijyen paketi.", Price = 25, CreatedDate = DateTime.Now, Status = DataStatus.Inserted },
                new ExtraService { Id = 7, Name = "Özel Plaj Alanı", Description = "Özel şezlong ve plaj hizmetleri.", Price = 35, CreatedDate = DateTime.Now, Status = DataStatus.Inserted }
            };

            modelBuilder.Entity<ExtraService>().HasData(extraServices);
        }
    }
}
