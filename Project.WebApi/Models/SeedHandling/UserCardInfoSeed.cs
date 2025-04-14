using Microsoft.EntityFrameworkCore;
using Project.WebApi.Models.Entities;

namespace NetCoreBank.Models.SeedHandling
{
    /// <summary>
    /// UserCardInfo tablosuna sahte kart verileri eklemek için kullanılan seed sınıfıdır.
    /// Geliştirme veya test ortamlarında kullanılmak üzere örnek kart bilgileri sağlar.
    /// </summary>
    public static class UserCardInfoSeed
    {
        /// <summary>
        /// Seed işlemi: ModelBuilder üzerinden UserCardInfo verilerini veritabanına enjekte eder.
        /// </summary>
        /// <param name="modelBuilder">EF Core'un yapılandırma aracı</param>
        public static void SeedUserCard(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCardInfo>().HasData(

                // İlk kullanıcı kart bilgisi
                new UserCardInfo
                {
                    Id = 1,
                    CardUserName = "Hakan Akinsu",                    // Kart sahibinin adı
                    CardNumber = "1111 1111 1111 1111",               // Kart numarası
                    CVV = "123",                                      // Güvenlik kodu
                    ExpiryMonth = 12,                                 // Son kullanma ayı
                    ExpiryYear = 2026,                                // Son kullanma yılı
                    CardLimit = 50000,                                // Kart limiti
                    Balance = 50000                                   // Mevcut bakiye
                },

                // İkinci kullanıcı kart bilgisi
                new UserCardInfo
                {
                    Id = 2,
                    CardUserName = "Test Member",
                    CardNumber = "2222 2222 2222 2222",
                    CVV = "456",
                    ExpiryMonth = 6,
                    ExpiryYear = 2025,
                    CardLimit = 75000,
                    Balance = 75000
                },

                // Üçüncü kullanıcı kart bilgisi
                new UserCardInfo
                {
                    Id = 3,
                    CardUserName = "Zeynep Demir",
                    CardNumber = "3333 3333 3333 3333",
                    CVV = "789",
                    ExpiryMonth = 9,
                    ExpiryYear = 2027,
                    CardLimit = 100000,
                    Balance = 100000
                }
            );
        }
    }
}
