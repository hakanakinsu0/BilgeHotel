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
    /// Employee, çalışan detayları (EmployeeDetail) ve vardiyalar (Shift) ile ilişkilidir.
    /// </summary>
    public class EmployeeConfiguration : BaseConfiguration<Employee>
    {
        /// <summary>
        /// Employee ile ilişkili yapılandırmaları belirler.
        /// - Employee ↔ EmployeeDetail bire bir (1:1) ilişki.
        /// - Employee ↔ EmployeeShift çoktan-çoğa (n:m) ilişki.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            // Employee ↔ EmployeeDetail bire bir ilişkisi
            builder.HasOne(x => x.EmployeeDetail) // Employee'in bir EmployeeDetail ilişkisi var.
                   .WithOne(x => x.Employee) // EmployeeDetail'in bir Employee ilişkisi var.
                   .HasForeignKey<EmployeeDetail>(x => x.EmployeeId); // EmployeeDetail içindeki EmployeeId foreign key olarak belirlenir.

        }
    }
}
