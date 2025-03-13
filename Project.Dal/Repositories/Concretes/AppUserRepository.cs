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
    /// Kullanıcılar (AppUser) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<AppUser>` aracılığıyla sağlanır.
    /// </summary>
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        /// <summary>
        /// `AppUserRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public AppUserRepository(MyContext context) : base(context) { }
    }
}
