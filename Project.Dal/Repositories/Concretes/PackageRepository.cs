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
    /// Otelde sunulan konaklama paketleri (Package) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<Package>` aracılığıyla sağlanır.
    /// </summary>
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
        /// <summary>
        /// `PackageRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public PackageRepository(MyContext context) : base(context) { }
    }
}
