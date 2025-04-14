using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// InventoryItem nesnelerine ait iş mantığını tanımlar.
    /// Donanım envanteri CRUD ve özel sorgulamalar bu arayüzde toplanır.
    /// </summary>
    public interface IInventoryItemManager : IManager<InventoryItemDto, InventoryItem>
    {
        /// <summary>
        /// Belirli bir lokasyonda bulunan donanımları getirir.
        /// </summary>
        Task<List<InventoryItemDto>> GetByLocationAsync(string location);

        /// <summary>
        /// Belirli bir kategoriye (örneğin: Bilgisayar, Server) göre filtreleme yapar.
        /// </summary>
        Task<List<InventoryItemDto>> GetByCategoryAsync(string category);
    }
}
