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
    /// Otel rezervasyonları (Reservation) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<Reservation>` aracılığıyla sağlanır.
    /// </summary>
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        /// <summary>
        /// `ReservationRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public ReservationRepository(MyContext context) : base(context) { }
    }
}
