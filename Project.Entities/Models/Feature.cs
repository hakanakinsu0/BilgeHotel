using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class Feature : BaseEntity
    {
        public string Name { get; set; } // Özellik adı (ör. "Klima").
        public string Description { get; set; } // Özellik açıklaması (opsiyonel).

        // Relational Properties
        public virtual ICollection<RoomFeature> RoomFeatures { get; set; } // Özelliğe sahip odalar ile ilişki.
    }
}
