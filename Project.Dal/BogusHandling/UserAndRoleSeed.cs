using Microsoft.AspNetCore.Identity;
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
    public static class UserAndRoleSeed
    {
        public static void SeedUsersAndRoles(ModelBuilder modelBuilder)
        {
            // **IdentityRole<int> yerine AppRole kullanıldı!**
            AppRole adminRole = new()
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            modelBuilder.Entity<AppRole>().HasData(adminRole);

            // **Şifre Hashleme İşlemi**
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
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

            modelBuilder.Entity<AppUser>().HasData(adminUser);

            // **IdentityUserRole<int> yerine AppUserRole Kullanıldı!**
            AppUserRole adminUserRole = new()
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
                CreatedDate = DateTime.Now,
                Status = DataStatus.Inserted
            };

            modelBuilder.Entity<AppUserRole>().HasData(adminUserRole);
        }
    }
}
