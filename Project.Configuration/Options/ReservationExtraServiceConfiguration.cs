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
    /// Veritabanında ReservationExtraService tablosunun yapılandırılmasını sağlar.
    /// Bu tablo, Rezervasyonlar (Reservation) ile Ekstra Hizmetler (ExtraService) arasındaki çoktan-çoğa (N:N) ilişkiyi yönetir.
    /// Junction Table (Bağlantı Tablosu) olarak görev yapar.
    /// </summary>
    public class ReservationExtraServiceConfiguration : BaseConfiguration<ReservationExtraService>
    {
        /// <summary>
        /// ReservationExtraService yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<ReservationExtraService> builder)
        {
            base.Configure(builder);

            // 1 Reservation N ReservationExtraService, 1 ReservationExtraService 1 Reservation
            builder.HasOne(x => x.Reservation).WithMany(x => x.ReservationExtraServices).HasForeignKey(x => x.ReservationId);

            // 1 ExtraService N ReservationExtraService, 1 ReservationExtraService 1 ExtraService
            builder.HasOne(x => x.ExtraService).WithMany(x => x.ReservationExtraServices).HasForeignKey(x => x.ExtraServiceId);
        }
    }
}