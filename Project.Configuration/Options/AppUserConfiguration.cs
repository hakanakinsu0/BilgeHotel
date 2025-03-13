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
    /// </summary>
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        /// <summary>
        /// AppUser ile ilişkili yapılandırmaları belirler.
        /// AppUser ile AppUserProfile bire bir (1:1) ilişki.
        /// </summary>
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            // 1 AppUser 1 AppUserProfile, 1 AppUserProfile 1 AppUser
            builder.HasOne(x => x.AppUserProfile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.AppUserId);
        }
    }
}
