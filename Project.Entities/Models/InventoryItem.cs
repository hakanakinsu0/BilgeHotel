using Project.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    /// <summary>
    /// Oteldeki donanım envanterlerini (bilgisayar, server, yazıcı vb.) temsil eder.
    /// Her cihazın adı, tipi, seri numarası, bulunduğu konum ve teknik açıklaması tutulur.
    /// </summary>
    public class InventoryItem : BaseEntity
    {
        public string Name { get; set; }           // Donanımın adı (örn: Masaüstü PC, Switch)
        public string SerialNumber { get; set; }   // Cihazın seri numarası
        public string Location { get; set; }       // Cihazın bulunduğu yer (örn: Resepsiyon, Bar)
        public string Description { get; set; }    // Teknik açıklama (örn: Intel i5, 8GB RAM)
        public string Category { get; set; }       // Donanım tipi (örn: Bilgisayar, Server, Yazıcı)

        // Foreign Keys
        public int EmployeeId { get; set; }

        // Relational Properties
        public virtual Employee Employee { get; set; } // 1 Employee N InventoryItem, 1 InventoryItem 1 Employee
    }
}
