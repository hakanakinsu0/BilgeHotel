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
    /// Kullanıcı profilleri (AppUserProfile) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<AppUserProfile>` aracılığıyla sağlanır.
    /// </summary>
    public class AppUserProfileRepository : BaseRepository<AppUserProfile>, IAppUserProfileRepository
    {
        /// <summary>
        /// `AppUserProfileRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public AppUserProfileRepository(MyContext context) : base(context) { }
    }
}
