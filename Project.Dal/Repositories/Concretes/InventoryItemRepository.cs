using Project.Dal.ContextClasses;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Concretes
{
    /// <summary>
    /// InventoryItem tablosuna ait veri erişim işlemlerini gerçekleştiren repository sınıfıdır.
    /// BaseRepository üzerinden tüm temel CRUD işlemleri devralınır.
    /// </summary>
    public class InventoryItemRepository : BaseRepository<InventoryItem>, IInventoryItemRepository
    {
        public InventoryItemRepository(MyContext context) : base(context)
        {
        }
    }
}
