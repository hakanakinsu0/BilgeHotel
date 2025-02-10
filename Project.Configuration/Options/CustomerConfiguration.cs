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

            builder.HasOne(x => x.CustomerDetail) // 1 Customer 1 CustomerDetail, 1 CustomerDetail 1 Customer
                   .WithOne(x => x.Customer)
                   .HasForeignKey<CustomerDetail>(x => x.CustomerId);

            builder.HasOne(x => x.AppUser) // 1 AppUser N Customer, 1 Customer 1 AppUser
                   .WithMany(x => x.Customers)
                   .HasForeignKey(x => x.AppUserId);
        }
    }
}
