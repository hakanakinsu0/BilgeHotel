using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Otelde sunulan ekstra hizmetler (ExtraService) için veri erişim işlemlerini yöneten repository interfacei.
    /// Tüm temel CRUD işlemleri `IRepository<ExtraService>` aracılığıyla sağlanır.
    /// </summary>
    public interface IExtraServiceRepository : IRepository<ExtraService>
    {
    }
}
