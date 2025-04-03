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
    public interface IRoomTypeManager : IManager<RoomTypeDto, RoomType> { }
}
