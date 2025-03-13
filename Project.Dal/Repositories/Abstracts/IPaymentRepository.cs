using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Otel ödemeleri (Payment) için veri erişim işlemlerini yöneten repository interface'i.
    /// Tüm temel CRUD işlemleri `IRepository<Payment>` aracılığıyla sağlanır.
    /// </summary>
    public interface IPaymentRepository : IRepository<Payment>
    {
    }
}
