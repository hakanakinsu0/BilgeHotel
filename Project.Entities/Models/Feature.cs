using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Feature : BaseEntity
    {
        /// <summary>
        /// Odalara atanabilecek özelliklerin (ör. Klima, Balkon) tanımlandığı sınıfı içerir.
        /// Özellikler, RoomFeature junction table aracılığıyla odalarla ilişkilendirilir.
        /// </summary>
        public string Name { get; set; } // Özellik adı (ör. "Klima").
        public string Description { get; set; } // Özellik açıklaması (opsiyonel).

        // Relational Properties
        public virtual ICollection<RoomFeature> RoomFeatures { get; set; } // Junction Table: 1 Feature N Room, 1 Room N Feature

    }
}
