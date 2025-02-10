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
    /// Veritabanında Shift tablosunun yapılandırılmasını sağlar.
    /// Shift, çalışanlar (Employee) ile çoktan-çoğa (n:m) ilişkiyi temsil eden EmployeeShift tablosuyla ilişkilidir.
    /// </summary>
    public class ShiftConfiguration : BaseConfiguration<Shift>
    {
        /// <summary>
        /// Shift yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<Shift> builder)
        {
            base.Configure(builder);

            // Shift tablosuna özel ek ayarlamalar bulunmamaktadır.
        }
    }
}
