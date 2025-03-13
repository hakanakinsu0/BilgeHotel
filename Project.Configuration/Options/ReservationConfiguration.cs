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
    /// </summary>
    public class ReservationConfiguration : BaseConfiguration<Reservation>
    {
        /// <summary>
        /// Reservation yapılandırmasını belirler.
        /// TotalPrice alanı "money" türüne çevrildi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TotalPrice).HasColumnType("money"); // Rezervasyon toplam tutarı, veritabanında "money" türünde saklanır.

            // 1 Reservation 1 Payment, 1 Payment 1 Reservation
            builder.HasOne(x => x.Payment).WithOne(x => x.Reservation).HasForeignKey<Payment>(x => x.ReservationId);
        }
    }
}
