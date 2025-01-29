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
    /// Veritabanında Customer tablosunun yapılandırılmasını sağlar.
    /// Customer, müşteri detayları (CustomerDetail) ve kullanıcı hesapları (AppUser) ile ilişkilidir.
    /// </summary>
    public class CustomerConfiguration : BaseConfiguration<Customer>
    {
        /// <summary>
        /// Customer ile ilişkili yapılandırmaları belirler.
        /// - Customer ↔ CustomerDetail bire bir (1:1) ilişki.
        /// - Customer ↔ AppUser bire çok (1:N) ilişki.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            // Customer ↔ CustomerDetail bire bir ilişkisi
            builder.HasOne(x => x.CustomerDetail)
                   .WithOne(x => x.Customer)
                   .HasForeignKey<CustomerDetail>(x => x.CustomerId);

            // Customer ↔ AppUser bire çok ilişkisi
            builder.HasOne(x => x.AppUser)
                   .WithMany(x => x.Customers)
                   .HasForeignKey(x => x.AppUserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
