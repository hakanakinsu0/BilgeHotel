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
        /// - TotalPrice alanı "money" türüne çevrildi.
        /// - Tüm ilişkiler düzenlendi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Reservation> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Customer) // 1 Customer N Reservation, 1 Reservation 1 Customer
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Room) // 1 Room N Reservation, 1 Reservation 1 Room
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.RoomId);

            builder.HasOne(x => x.Package) // 1 Package N Reservation, 1 Reservation 1 Package
                   .WithMany(x => x.Reservations)
                   .HasForeignKey(x => x.PackageId);

            builder.Property(x => x.TotalPrice) 
                   .HasColumnType("money"); // Decimal veri tipi, veritabanında money olarak saklanır.
        }
    }
}
