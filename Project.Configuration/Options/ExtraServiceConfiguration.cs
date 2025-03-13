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
    /// Veritabanında ExtraService tablosunun yapılandırılmasını sağlar.
    /// ExtraService, otelde sunulan ek hizmetleri temsil eder (ör. Spa, Oda Servisi, Minibar Kullanımı).
    /// </summary>
    public class ExtraServiceConfiguration : BaseConfiguration<ExtraService>
    {
        /// <summary>
        /// ExtraService ile ilişkili yapılandırmaları belirler.
        /// Fiyat alanı "money" türü olarak saklanır.
        /// </summary>
        public override void Configure(EntityTypeBuilder<ExtraService> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Price).HasColumnType("money"); // Hizmet fiyatı veritabanında "money" türünde saklanır.
        }
    }
}
