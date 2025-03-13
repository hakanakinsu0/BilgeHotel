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
    /// Veritabanında Employee tablosunun yapılandırılmasını sağlar.
    /// </summary>
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        /// <summary>
        /// Employee ile ilişkili yapılandırmaları belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Salary).HasColumnType("money"); // Çalışanın maaşı veritabanında money türünde saklanır.
        }
    }
}
