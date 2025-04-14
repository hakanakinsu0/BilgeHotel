using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// Oda türlerine ilişkin iş kurallarını yöneten manager sınıfıdır.
    /// Temel CRUD işlemleri BaseManager üzerinden devralınmıştır.
    /// </summary>
    public class RoomTypeManager : BaseManager<RoomTypeDto, RoomType>, IRoomTypeManager
    {
        readonly IRoomTypeRepository _repository;
        public RoomTypeManager(IRoomTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Verilen oda tipi adına karşılık gelen ID'yi döner.
        /// Eşleşme yoksa null döner.
        /// </summary>
        /// <param name="name">Oda türü adı (ör: "Kral Dairesi")</param>
        /// <returns>Oda türü ID'si veya null</returns>
        public async Task<int?> GetRoomTypeIdByNameAsync(string name)
        {
            // İsme göre oda tipi sorgulanır
            RoomType type = await _repository.Where(rt => rt.Name == name).FirstOrDefaultAsync();

            // Oda tipi varsa ID döner, yoksa null
            return type?.Id;
        }
    }
}
