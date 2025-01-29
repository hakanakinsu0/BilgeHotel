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
    /// Veritabanında Payment tablosunun yapılandırılmasını sağlar.
    /// Payment, rezervasyonlar (Reservation) ile bire bir (1:1) ilişkilidir.
    /// </summary>
    public class PaymentConfiguration : BaseConfiguration<Payment>
    {
        /// <summary>
        /// Payment yapılandırmasını belirler.
        /// - Decimal tipli PaymentAmount alanı "money" türüne çevrildi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            // Decimal alanları "money" türüne çeviriyoruz.
            builder.Property(x => x.PaymentAmount).HasColumnType("money");
        }
    }
}
