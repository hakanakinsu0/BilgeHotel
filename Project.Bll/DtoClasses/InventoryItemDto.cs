using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DtoClasses
{
    /// <summary>
    /// InventoryItem entity’sini temsil eden veri transfer (DTO) sınıfıdır.
    /// UI katmanına taşınacak donanım bilgilerini içerir.
    /// </summary>
    public class InventoryItemDto : BaseDto
    {
        public string Name { get; set; }           // Donanım adı
        public string SerialNumber { get; set; }   // Seri numarası
        public string Location { get; set; }       // Fiziksel konum
        public string Description { get; set; }    // Teknik açıklama
        public string Category { get; set; }       // Bilgisayar, Server vs.
        public int EmployeeId { get; set; }        // IT sorumlusunun ID'si
        public string EmployeeFullName { get; set; } // View tarafı için (örn: "Selahattin Karadibag")
        public string EmployeePosition { get; set; } // View'de "Sorumlu Birim" olarak kullanılacak

    }
}
