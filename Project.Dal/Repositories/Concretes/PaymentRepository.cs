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
    /// Otel ödemeleri (Payment) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<Payment>` aracılığıyla sağlanır.
    /// </summary>
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        /// <summary>
        /// `PaymentRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public PaymentRepository(MyContext context) : base(context) { }
    }
}
