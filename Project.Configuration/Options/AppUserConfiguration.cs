using Microsoft.EntityFrameworkCore;
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
        /// - AppUser ↔ AppUserRole çoktan-çoğa (n:m) ilişki.
        /// - AppUser ↔ Customer bire çok (1:N) ilişki.
        /// </summary>
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.AppUserProfile) // 1 AppUser 1 AppUserProfile, 1 AppUserProfile 1 AppUser
                   .WithOne(x => x.AppUser)
                   .HasForeignKey<AppUserProfile>(x => x.AppUserId);

        }
    }
}
