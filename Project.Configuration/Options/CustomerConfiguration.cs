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
    /// Customer, müşteri detayları (CustomerDetail) ile ilişkilidir.
    /// </summary>
    public class CustomerConfiguration : BaseConfiguration<Customer>
    {
        /// <summary>
        /// Customer ile ilişkili yapılandırmaları belirler.
        /// - Customer ↔ CustomerDetail bire bir (1:1) ilişki.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            // Customer ↔ CustomerDetail bire bir ilişkisi
            builder.HasOne(x => x.CustomerDetail) // Customer'in bir CustomerDetail ilişkisi var.
                   .WithOne(x => x.Customer) // CustomerDetail'in bir Customer ilişkisi var.
                   .HasForeignKey<CustomerDetail>(x => x.CustomerId); // CustomerDetail içindeki CustomerId foreign key olarak belirlenir.
        }
    }
}
