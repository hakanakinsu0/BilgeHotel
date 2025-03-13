using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Otel oda türleri (RoomType) için veri erişim işlemlerini yöneten repository interface'i.
    /// Tüm temel CRUD işlemleri `IRepository<RoomType>` aracılığıyla sağlanır.
    /// </summary>
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
    }
}
