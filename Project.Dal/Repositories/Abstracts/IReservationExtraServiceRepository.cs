using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Rezervasyonlara eklenen ekstra hizmetler (ReservationExtraService) için veri erişim işlemlerini yöneten repository interface'i.
    /// Tüm temel CRUD işlemleri `IRepository<ReservationExtraService>` aracılığıyla sağlanır.
    /// </summary>
    public interface IReservationExtraServiceRepository : IRepository<ReservationExtraService>
    {
        /// <summary>
        /// Birden fazla ekstra hizmeti aynı anda eklemeyi sağlar.
        /// </summary>
        /// <param name="entities">Eklenmek istenen ekstra hizmetlerin listesi.</param>
        Task CreateRangeAsync(List<ReservationExtraService> entities); 
    }
}
