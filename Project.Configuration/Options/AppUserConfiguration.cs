using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    /// <summary>
    /// Veritabanında AppUser tablosunun yapılandırılmasını sağlar.
    /// AppUser, kullanıcı profili (AppUserProfile) ve kullanıcı rolleri (AppUserRole) ile ilişkilidir.
    /// </summary>
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        /// <summary>
        /// AppUser ile ilişkili yapılandırmaları belirler.
        /// - AppUser ↔ AppUserProfile bire bir (1:1) ilişki.
        /// - AppUser ↔ AppUserRole çoktan çoğa (n:m) ilişki.
        /// - AppUserRole içindeki UserId alanı foreign key olarak belirlenmiştir.
        /// </summary>
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            // AppUser ↔ AppUserProfile ilişkisi
            builder.HasOne(x => x.AppUserProfile) // AppUser'in bir AppUserProfile ilişkisi var.
                   .WithOne(x => x.AppUser) // AppUserProfile'in bir AppUser ilişkisi var.
                   .HasForeignKey<AppUserProfile>(x => x.Id); // AppUserProfile içindeki Id foreign key olarak kullanılır.

            // AppUser ↔ AppUserRole ilişkisi
            builder.HasMany(x => x.UserRoles) // AppUser'in birden fazla UserRole ilişkisi var.
                   .WithOne(x => x.User) // Her UserRole'in bir AppUser ilişkisi var.
                   .HasForeignKey(x => x.UserId) // UserRole içindeki UserId foreign key olarak kullanılır.
                   .IsRequired(); // Foreign key zorunludur.
        }
    }
}
