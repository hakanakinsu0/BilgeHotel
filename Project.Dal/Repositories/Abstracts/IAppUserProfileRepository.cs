using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Kullanıcı profilleri için veri erişim işlemlerini yöneten repository interfacei.
    /// Tüm temel CRUD işlemleri `IRepository<AppUserProfile>` aracılığıyla sağlanır.
    /// </summary>
    public interface IAppUserProfileRepository : IRepository<AppUserProfile>
    {
    }
}
