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
    /// InventoryItem tablosunun Fluent API konfigürasyonlarını içerir.
    /// </summary>
    public class InventoryItemConfiguration : BaseConfiguration<InventoryItem>
    {
        /// <summary>
        /// InventoryItem yapılandırmasını belirler.
        /// </summary>
        public override void Configure(EntityTypeBuilder<InventoryItem> builder)
        {
            base.Configure(builder);
        }
    }
}