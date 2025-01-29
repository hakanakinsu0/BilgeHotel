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
    /// Veritabanında CustomerDetail tablosunun yapılandırılmasını sağlar.
    /// CustomerDetail, müşteri detay bilgilerini temsil eder.
    /// </summary>
    public class CustomerDetailConfiguration : BaseConfiguration<CustomerDetail>
    {
        /// <summary>
        /// CustomerDetail yapılandırmalarını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<CustomerDetail> builder)
        {
            base.Configure(builder);

            // CustomerDetail'a özel alanlara yönelik ayarlamalar yapılabilir.

        }
    }
}
