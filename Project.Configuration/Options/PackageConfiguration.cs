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
    /// Veritabanında Package tablosunun yapılandırılmasını sağlar.
    /// Package, rezervasyonlar (Reservation) ile bire çok (1:N) ilişkilidir.
    /// </summary>
    public class PackageConfiguration : BaseConfiguration<Package>
    {
        /// <summary>
        /// Package yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Package> builder)
        {
            base.Configure(builder);
        }
    }
}
