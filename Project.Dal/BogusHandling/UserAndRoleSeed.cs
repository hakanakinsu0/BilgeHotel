using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;

namespace Project.Dal.BogusHandling
{
    /// <summary>
    /// Kullanıcı ve rol verilerini başlangıçta veritabanına eklemek için kullanılır.
    /// Admin ve Member rollerini oluşturur, kullanıcıları ekler ve rollerini atar.
    /// </summary>
    public static class UserAndRoleSeed
    {
        /// <summary>
        /// ModelBuilder kullanarak kullanıcı ve rol verilerini seed (ön yükleme) yapar.
        /// </summary>
        public static void SeedUsersAndRoles(ModelBuilder modelBuilder)
        {
            // Rolleri Tanımlıyoruz
            IdentityRole<int> adminRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString() // Rol için benzersiz bir kimlik oluşturuluyor
            };

            IdentityRole<int> memberRole = new()
            {
                Id = 2,
                Name = "Member",
                NormalizedName = "MEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(adminRole, memberRole);

            // Şifre Hashleme İşlemi İçin PasswordHasher Kullanımı
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            // Admin Kullanıcısını Oluşturuyoruz
            AppUser adminUser = new()
            {
                Id = 1,
                UserName = "bilgehotel",
                Email = "bilgehotel@email.com",
                NormalizedEmail = "BILGEHOTEL@EMAIL.COM",
                NormalizedUserName = "BILGEHOTEL",
                EmailConfirmed = true, // E-posta onaylandı olarak işaretlendi
                SecurityStamp = Guid.NewGuid().ToString(), // Güvenlik mührü
                PasswordHash = passwordHasher.HashPassword(null, "bilgehotel"), // Şifre hashleniyor
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // Örnek Member Kullanıcısını Oluşturuyoruz
            AppUser memberUser = new()
            {
                Id = 2,
                UserName = "testmember",
                Email = "testmember@email.com",
                NormalizedEmail = "TESTMEMBER@EMAIL.COM",
                NormalizedUserName = "TESTMEMBER",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "testmember"),
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            modelBuilder.Entity<AppUser>().HasData(adminUser, memberUser);

            // Admin Kullanıcısına Rol Ataması
            IdentityUserRole<int> adminUserRole = new()
            {
                RoleId = 1, // Admin rolü
                UserId = 1  // Admin kullanıcı
            };

            // Member Kullanıcısına Rol Ataması
            IdentityUserRole<int> memberUserRole = new()
            {
                RoleId = 2, // Member rolü
                UserId = 2  // Test müşteri kullanıcı
            };

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRole, memberUserRole);
        }
    }
}
