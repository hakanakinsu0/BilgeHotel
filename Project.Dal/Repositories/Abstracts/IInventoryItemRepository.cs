using Project.Dal.Repositories.Concretes;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// InventoryItem tablosuna ait veri erişim işlemlerini tanımlayan repository arayüzüdür.
    /// BaseRepository üzerinden tüm temel CRUD işlemleri devralınır.
    /// </summary>
    public interface IInventoryItemRepository : IRepository<InventoryItem>
    {
    }
}
