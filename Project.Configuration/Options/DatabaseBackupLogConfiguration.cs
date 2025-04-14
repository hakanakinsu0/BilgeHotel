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
    /// DatabaseBackupLog tablosunun EF Core yapılandırmasını yapar.
    /// </summary>
    public class DatabaseBackupLogConfiguration : BaseConfiguration<DatabaseBackupLog>
    {
        /// <summary>
        /// DatabaseBackupLog yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<DatabaseBackupLog> builder)
        {
            base.Configure(builder);
        }
    }
}
