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
    /// Veritabanında AppUserRole tablosunun yapılandırılmasını sağlar.
    /// AppUserRole, kullanıcılar (AppUser) ve roller (AppRole) arasındaki çoktan-çoğa (n:m) ilişkiyi temsil eder.
    /// </summary>
    public class AppUserRoleConfiguration : BaseConfiguration<AppUserRole>
    {
        /// <summary>
        /// AppUserRole yapılandırmasını belirler.
        /// - Kullanıcı ve rol ilişkisini tanımlamak için benzersiz bir indeks (UserId, RoleId) oluşturur.
        /// - Her UserId ve RoleId kombinasyonu, tabloda benzersiz bir kayıt olmasını garanti eder.
        /// </summary>
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            base.Configure(builder);

            // Kullanıcı ve rol kombinasyonunu benzersiz hale getiren indeks
            builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
        }
    }
}
