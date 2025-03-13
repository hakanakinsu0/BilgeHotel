using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;

namespace Project.Dal.BogusHandling
{
    /// <summary>
    /// Sahte (fake) ekstra hizmet verilerini oluşturur ve veritabanına ekler.
    /// ExtraService tablosuna örnek hizmetleri eklemek için kullanılır.
    /// </summary>
    public static class ExtraServiceSeed
    {
        /// <summary>
        /// ModelBuilder kullanarak ExtraService verilerini seed (ön yükleme) yapar.
        /// </summary>
        public static void SeedExtraServices(ModelBuilder modelBuilder)
        {
            // Otele ait ekstra hizmetler tanımlanıyor.
            List<ExtraService> extraServices = new()
            {
                new ExtraService 
                {
                    Id = 1,
                    Name = "Spa Kullanımı",
                    Description = "Günlük sınırsız spa kullanımı.",
                    Price = 3000,
                    CreatedDate = DateTime.Now,
                    Status = DataStatus.Inserted
                },

                new ExtraService 
                {
                    Id = 2, 
                    Name = "Oda Servisi", 
                    Description = "24 saat oda servisi. Tüm yemek siparişleri dahildir.", 
                    Price = 1500, 
                    CreatedDate = DateTime.Now, 
                    Status = DataStatus.Inserted 
                },

                new ExtraService { 
                    Id = 3, 
                    Name = "Minibar Kullanımı", 
                    Description = "Minibardaki içecekler ve atıştırmalıklar dahil.",
                    Price = 1000, 
                    CreatedDate = DateTime.Now, 
                    Status = DataStatus.Inserted 
                },

                new ExtraService 
                { 
                    Id = 4, 
                    Name = "Havalimanı Transferi", 
                    Description = "Gidiş-dönüş özel araç transferi.", 
                    Price = 5000, 
                    CreatedDate = DateTime.Now, 
                    Status = DataStatus.Inserted 
                },

                new ExtraService 
                { 
                    Id = 5, 
                    Name = "Çamaşırhane Hizmeti", 
                    Description = "Konaklama süresince ücretsiz çamaşır ve kuru temizleme hizmeti.", 
                    Price = 500, 
                    CreatedDate = DateTime.Now, 
                    Status = DataStatus.Inserted 
                },

                new ExtraService 
                { 
                    Id = 6, 
                    Name = "Günlük Oda Temizliği", 
                    Description = "Ekstra günlük temizlik ve hijyen paketi.", 
                    Price = 500, 
                    CreatedDate = DateTime.Now, 
                    Status = DataStatus.Inserted 
                },

                new ExtraService 
                { 
                    Id = 7, 
                    Name = "Özel Plaj Alanı", 
                    Description = "Özel şezlong ve plaj hizmetleri.", 
                    Price = 7500, 
                    CreatedDate = DateTime.Now, 
                    Status = DataStatus.Inserted 
                }
            };

            //EF Core ile verileri veritabanına ekleme işlemi
            modelBuilder.Entity<ExtraService>().HasData(extraServices);
        }
    }
}
