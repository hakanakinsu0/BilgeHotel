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
    /// Veritabanında AppRole tablosunun yapılandırılmasını sağlar.
    /// AppRole, kullanıcı rolleriyle (AppUserRole) ilişkilidir.
    /// </summary>
    public class AppRoleConfiguration : BaseConfiguration<AppRole>
    {
        /// <summary>
        /// AppRole ile ilişkili yapılandırmaları belirler.
        /// - AppRole ↔ AppUserRole ilişkisini yönetir.
        /// - Bir AppRole birden fazla AppUserRole ile ilişkilidir.
        /// - AppUserRole içindeki RoleId alanı foreign key olarak belirlenmiştir.
        /// </summary>
        public override void Configure(EntityTypeBuilder<AppRole> builder)
        {
            base.Configure(builder);

            // AppRole ↔ AppUserRole ilişkisi
            builder.HasMany(x => x.UserRoles) // AppRole'in birden fazla UserRole ilişkisi var.
                   .WithOne(x => x.Role) // Her UserRole'in bir Role ilişkisi var.
                   .HasForeignKey(x => x.RoleId) // UserRole içindeki RoleId foreign key olarak kullanılır.
                   .IsRequired(); // Foreign key zorunludur.
        }
    }
}
