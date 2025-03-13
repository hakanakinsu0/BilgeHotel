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
    /// Reservation, müşteri (AppUser), oda (Room), paket (Package) ve ödeme (Payment) bilgileri ile ilişkilidir.
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

            // 1 AppUser N Reservation, 1 Reservation 1 AppUser
            //builder.HasOne(x => x.AppUser).WithMany(x => x.Reservations).HasForeignKey(x => x.AppUserId);

            // 1 Room N Reservation, 1 Reservation 1 Room
            //builder.HasOne(x => x.Room).WithMany(x => x.Reservations).HasForeignKey(x => x.RoomId);

            // 1 Package N Reservation, 1 Reservation 1 Package
            //builder.HasOne(x => x.Package).WithMany(x => x.Reservations).HasForeignKey(x => x.PackageId);

            // 1 Reservation 1 Payment, 1 Payment 1 Reservation
            builder.HasOne(x => x.Payment).WithOne(x => x.Reservation).HasForeignKey<Payment>(x => x.ReservationId);

            // 1 Employee N Reservation, 1 Reservation 1 Employee
            //builder.HasOne(x => x.Employee).WithMany(x => x.ManagedReservations).HasForeignKey(x => x.EmployeeId);
        }
    }
}
