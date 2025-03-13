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
    /// Oteldeki oda türleri (RoomType) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<RoomType>` aracılığıyla sağlanır.
    /// </summary>
    public class RoomTypeRepository : BaseRepository<RoomType>, IRoomTypeRepository
    {
        /// <summary>
        /// `RoomTypeRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public RoomTypeRepository(MyContext context) : base(context) { }
    }
}
