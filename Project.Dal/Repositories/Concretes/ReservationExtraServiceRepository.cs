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
    /// Rezervasyonlara eklenen ekstra hizmetler (ReservationExtraService) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<ReservationExtraService>` aracılığıyla sağlanır.
    /// </summary>
    public class ReservationExtraServiceRepository : BaseRepository<ReservationExtraService>, IReservationExtraServiceRepository
    {
        /// <summary>
        /// `ReservationExtraServiceRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public ReservationExtraServiceRepository(MyContext context) : base(context) { }

        /// <summary>
        /// Birden fazla ekstra hizmeti aynı anda eklemeyi sağlar.
        /// </summary>
        /// <param name="entities">Eklenmek istenen ekstra hizmetlerin listesi.</param>
        public async Task CreateRangeAsync(List<ReservationExtraService> entities)
        {
            await _dbSet.AddRangeAsync(entities);                                  // DbSet üzerinden çoklu veri ekleme işlemi.
            await _context.SaveChangesAsync();                                      // Değişiklikleri veritabanına kaydeder.
        }
    }
}