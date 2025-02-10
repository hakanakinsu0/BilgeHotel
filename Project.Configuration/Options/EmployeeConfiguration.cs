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
    /// Employee, çalışan detayları (EmployeeDetail) ve rezervasyon yönetimi (Reservation) ile ilişkilidir.
    /// </summary>
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        /// <summary>
        /// Employee ile ilişkili yapılandırmaları belirler.
        /// - Employee ↔ EmployeeDetail bire bir (1:1) ilişki.
        /// - Employee ↔ Reservation bire çok (1:N) ilişki.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.EmployeeDetail) // 1 Employee 1 EmployeeDetail, 1 EmployeeDetail 1 Employee
                   .WithOne(x => x.Employee)
                   .HasForeignKey<EmployeeDetail>(x => x.EmployeeId);

            builder.HasMany(x => x.ManagedReservations) // 1 Employee N Reservation, 1 Reservation 1 Employee
                   .WithOne(x => x.Employee)
                   .HasForeignKey(x => x.EmployeeId)
                   .IsRequired();
        }
    }
}
