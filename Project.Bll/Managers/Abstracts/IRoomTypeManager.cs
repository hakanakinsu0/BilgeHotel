using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Oteldeki oda türleri ile ilgili işlemleri tanımlayan arayüzdür.
    /// Bu arayüz, oda türlerine ilişkin genel CRUD işlemlerini IManager arayüzü üzerinden sağlar.
    /// </summary>
    public interface IRoomTypeManager : IManager<RoomTypeDto, RoomType> 
    {
        /// <summary>
        /// Verilen oda türü adına karşılık gelen RoomType ID'sini asenkron olarak getirir.
        /// Eğer belirtilen isimde bir oda türü bulunamazsa null döner.
        /// </summary>
        /// <param name="name">Oda türü adı (ör. "Tek Kişilik", "Kral Dairesi")</param>
        /// <returns>Oda türünün ID'si veya null</returns>
        Task<int?> GetRoomTypeIdByNameAsync(string name);
    }
}
