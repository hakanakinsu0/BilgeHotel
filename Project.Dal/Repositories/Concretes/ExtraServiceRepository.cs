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
    /// Otelde sunulan ekstra hizmetler (ExtraService) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<ExtraService>` aracılığıyla sağlanır.
    /// </summary>
    public class ExtraServiceRepository : BaseRepository<ExtraService>, IExtraServiceRepository
    {
        /// <summary>
        /// `ExtraServiceRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public ExtraServiceRepository(MyContext context) : base(context) { }
    }
}