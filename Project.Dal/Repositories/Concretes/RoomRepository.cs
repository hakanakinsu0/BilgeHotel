using Microsoft.EntityFrameworkCore;
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
    /// Oteldeki odalar (Room) için veri erişim işlemlerini yöneten repository sınıfı.
    /// Temel CRUD işlemleri `BaseRepository<Room>` aracılığıyla sağlanır.
    /// </summary>
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        /// <summary>
        /// `RoomRepository` constructor'ı, veritabanı bağlantısını `BaseRepository`'ye iletir.
        /// </summary>
        /// <param name="context">Veritabanı bağlantısını sağlayan MyContext nesnesi.</param>
        public RoomRepository(MyContext context) : base(context) { }

        /// <summary>
        /// Oda numarasına göre belirli bir oda bilgisini getirir.
        /// </summary>
        /// <param name="roomNumber">Aranacak oda numarası.</param>
        /// <returns>Belirtilen numaraya sahip oda bilgisi.</returns>
        public async Task<Room> GetByRoomNumberAsync(string roomNumber)
        {
            return await Where(r => r.RoomNumber == roomNumber).FirstOrDefaultAsync();
        }
    }
}