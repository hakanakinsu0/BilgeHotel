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
    /// Veritabanında RoomType tablosunun yapılandırılmasını sağlar.
    /// </summary>
    public class RoomTypeConfiguration : BaseConfiguration<RoomType>
    {
        /// <summary>
        /// RoomType yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<RoomType> builder)
        {
            base.Configure(builder);
        }
    }
}
