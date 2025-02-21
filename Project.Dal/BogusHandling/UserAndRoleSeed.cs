using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;

namespace Project.Dal.BogusHandling
{
    public static class UserAndRoleSeed
    {
        public static void SeedUsersAndRoles(ModelBuilder modelBuilder)
        {
            // **IdentityRole<int> Kullanımı**
            IdentityRole<int> adminRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            IdentityRole<int> memberRole = new()
            {
                Id = 2,
                Name = "Member",
                NormalizedName = "MEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            modelBuilder.Entity<IdentityRole<int>>().HasData(adminRole, memberRole);

            // **Şifre Hashleme İşlemi**
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

            // **Admin Kullanıcısı**
            AppUser adminUser = new()
            {
                Id = 1,
                UserName = "bilgehotel",
                Email = "bilgehotel@email.com",
                NormalizedEmail = "BILGEHOTEL@EMAIL.COM",
                NormalizedUserName = "BILGEHOTEL",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "bilgehotel"),
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            // **Örnek Member Kullanıcısı**
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

            // **Admin Kullanıcısına Rol Ataması**
            IdentityUserRole<int> adminUserRole = new()
            {
                RoleId = 1, // Admin rolü
                UserId = 1  // Admin kullanıcı
            };

            // **Member Kullanıcısına Rol Ataması**
            IdentityUserRole<int> memberUserRole = new()
            {
                RoleId = 2, // Member rolü
                UserId = 2  // Test müşteri kullanıcı
            };

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(adminUserRole, memberUserRole);
        }
    }
}
