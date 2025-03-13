using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Otelde sunulan konaklama paketleri (Package) için veri erişim işlemlerini yöneten repository interface'i.
    /// Tüm temel CRUD işlemleri `IRepository<Package>` aracılığıyla sağlanır.
    /// </summary>
    public interface IPackageRepository : IRepository<Package>
    {
    }
}
