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
    /// Veritabanında RoomFeature tablosunun yapılandırılmasını sağlar.
    /// RoomFeature, odalar (Room) ve özellikler (Feature) arasındaki çoktan-çoğa (n:m) ilişkiyi temsil eder.
    /// </summary>
    public class RoomFeatureConfiguration : BaseConfiguration<RoomFeature>
    {
        /// <summary>
        /// RoomFeature yapılandırmasını belirler.
        /// - RoomId ve FeatureId alanları için benzersiz bir indeks oluşturur.
        /// </summary>
        public override void Configure(EntityTypeBuilder<RoomFeature> builder)
        {
            base.Configure(builder);

            // Çoktan-çoğa ilişkiyi temsil eden indeks
            builder.HasIndex(x => new { x.RoomId, x.FeatureId }).IsUnique();
        }
    }
}
