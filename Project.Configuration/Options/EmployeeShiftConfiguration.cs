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
    /// Veritabanında EmployeeShift tablosunun yapılandırılmasını sağlar.
    /// EmployeeShift, çalışanlar (Employee) ve vardiyalar (Shift) arasındaki çoktan-çoğa (n:m) ilişkiyi temsil eder.
    /// </summary>
    public class EmployeeShiftConfiguration : BaseConfiguration<EmployeeShift>
    {
        /// <summary>
        /// EmployeeShift yapılandırmasını belirler.
        /// - EmployeeShift tablosunda EmployeeId ve ShiftId alanları için benzersiz bir kombinasyon oluşturur.
        /// </summary>
        public override void Configure(EntityTypeBuilder<EmployeeShift> builder)
        {
            base.Configure(builder);

            // Çoktan-çoğa ilişkiyi temsil eden indeks
            builder.HasIndex(x => new { x.EmployeeId, x.ShiftId }).IsUnique();
        }
    }
}
