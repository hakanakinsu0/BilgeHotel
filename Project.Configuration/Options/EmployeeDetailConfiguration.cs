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
    /// Veritabanında EmployeeDetail tablosunun yapılandırılmasını sağlar.
    /// EmployeeDetail, çalışanların detaylı bilgilerini temsil eder.
    /// </summary>
    public class EmployeeDetailConfiguration : BaseConfiguration<EmployeeDetail>
    {
        /// <summary>
        /// EmployeeDetail yapılandırmalarını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<EmployeeDetail> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Salary) 
                   .HasColumnType("money"); // Veritabanında Salary alanının veri tipi decimal yerine money olarak ayarlanır.
        }
    }
}
