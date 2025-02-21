using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configuration.Options
{
    public class ReservationExtraServiceConfiguration : BaseConfiguration<ReservationExtraService>
    {
        public override void Configure(EntityTypeBuilder<ReservationExtraService> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Reservation)
                   .WithMany(x => x.ReservationExtraServices)
                   .HasForeignKey(x => x.ReservationId);

            builder.HasOne(x => x.ExtraService)
                   .WithMany(x => x.ReservationExtraServices)
                   .HasForeignKey(x => x.ExtraServiceId);
        }
    }
}