using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Dal.Repositories.Abstracts
{
    /// <summary>
    /// Oteldeki odalar (Room) için veri erişim işlemlerini yöneten repository interface'i.
    /// Tüm temel CRUD işlemleri `IRepository<Room>` aracılığıyla sağlanır.
    /// </summary>
    public interface IRoomRepository : IRepository<Room>
    {
        /// <summary>
        /// Oda numarasına göre belirli bir oda bilgisini getirir.
        /// </summary>
        /// <param name="roomNumber">Aranacak oda numarası.</param>
        /// <returns>Belirtilen numaraya sahip oda bilgisi.</returns>
        Task<Room> GetByRoomNumberAsync(string roomNumber);
    }
}
