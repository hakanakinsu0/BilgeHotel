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
    /// Veritabanında AppUserProfile tablosunun yapılandırılmasını sağlar.
    /// </summary>
    public class AppUserProfileConfiguration : BaseConfiguration<AppUserProfile>
    {
        /// <summary>
        /// AppUserProfile yapılandırmalarını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            base.Configure(builder);

            // AppUserProfile'a özel ekstra yapılandırma yok.
        }
    }
}
