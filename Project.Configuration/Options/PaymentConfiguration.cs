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
    /// </summary>
    public class PaymentConfiguration : BaseConfiguration<Payment>
    {
        /// <summary>
        /// Payment yapılandırmasını belirler.
        /// PaymentAmount alanı "money" türüne çevrildi.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Payment> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.PaymentAmount).HasColumnType("money"); // Ödeme tutarı, veritabanında "money" türünde saklanır.
        }
    }
}
