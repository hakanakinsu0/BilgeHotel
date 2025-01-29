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
    /// Veritabanında Feature tablosunun yapılandırılmasını sağlar.
    /// Feature, odalar (Room) ile çoktan-çoğa (n:m) ilişkiyi temsil eden RoomFeature tablosuyla ilişkilidir.
    /// </summary>
    public class FeatureConfiguration : BaseConfiguration<Feature>
    {
        /// <summary>
        /// Feature yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Feature> builder)
        {
            base.Configure(builder);

            // Feature tablosunda özel bir yapılandırma şu anda gerekmiyor.

        }
    }
}
