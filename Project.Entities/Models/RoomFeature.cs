using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Odalar ile özellikler arasındaki ilişkiyi temsil eder.
    /// Junction table olarak kullanılır.
    /// </summary>
    public class RoomFeature : BaseEntity
    {
        // Foreign Keys
        public int RoomId { get; set; } // İlişkili oda.
        public int FeatureId { get; set; } // İlişkili özellik.

        // Relational Properties
        public virtual Room Room { get; set; } // Oda ile ilişki.
        public virtual Feature Feature { get; set; } // Özellik ile ilişki.
    }
}
