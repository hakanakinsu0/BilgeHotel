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
 /// Room, oda türü (RoomType), oda özellikleri (RoomFeature) ve rezervasyonlar (Reservation) ile ilişkilidir.
 /// </summary>
    public class RoomConfiguration : BaseConfiguration<Room>
    {
        /// <summary>
        /// Room yapılandırmasını belirler.
        /// - Decimal tipli PricePerNight alanı "money" türüne çevrildi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            // Decimal alanları "money" türüne çeviriyoruz.
            builder.Property(x => x.PricePerNight).HasColumnType("money");
        }
    }
}
