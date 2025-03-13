using Microsoft.EntityFrameworkCore;
using Project.WebApi.Models.Entities;

namespace NetCoreBank.Models.SeedHandling
{
    public static class UserCardInfoSeed
    {
        public static void SeedUserCard(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCardInfo>().HasData(
                new UserCardInfo
                {
                    Id = 1,
                    CardUserName = "Hakan Akinsu",
                    CardNumber = "1111 1111 1111 1111",
                    CVV = "123",
                    ExpiryMonth = 12,
                    ExpiryYear = 2026,
                    CardLimit = 50000,
                    Balance = 50000
                },
                new UserCardInfo
                {
                    Id = 2,
                    CardUserName = "Mehmet Kaya",
                    CardNumber = "2222 2222 2222 2222",
                    CVV = "456",
                    ExpiryMonth = 6,
                    ExpiryYear = 2025,
                    CardLimit = 75000,
                    Balance = 75000
                },
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
