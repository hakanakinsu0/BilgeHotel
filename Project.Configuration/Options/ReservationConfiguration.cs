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
    /// Veritabanında Reservation tablosunun yapılandırılmasını sağlar.
    /// Reservation, müşteri (Customer), oda (Room), paket (Package) ve ödeme (Payment) bilgileri ile ilişkilidir.
    /// </summary>
    public class ReservationConfiguration : BaseConfiguration<Reservation>
    {
        /// <summary>
        /// Reservation yapılandırmasını belirler.
        /// - Decimal tipli TotalPrice alanı "money" türüne çevrildi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            // Decimal alanları "money" türüne çeviriyoruz.
            builder.Property(x => x.TotalPrice).HasColumnType("money");
        }
    }
}
