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
    /// Veritabanında Room tablosunun yapılandırılmasını sağlar.
    /// </summary>
    public class RoomConfiguration : BaseConfiguration<Room>
    {
        /// <summary>
        /// Room yapılandırmasını belirler.
        /// Decimal tipli PricePerNight alanı "money" türüne çevrildi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.PricePerNight).HasColumnType("money"); // Decimal veri tipi, veritabanında money olarak saklanır.
        }
    }
}
