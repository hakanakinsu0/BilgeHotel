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
    public class RoomTypeManager : BaseManager<RoomTypeDto, RoomType>, IRoomTypeManager
    {
        readonly IRoomTypeRepository _repository;
        public RoomTypeManager(IRoomTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<int?> GetRoomTypeIdByNameAsync(string name)
        {
            var type = await _repository.Where(rt => rt.Name == name).FirstOrDefaultAsync();
            return type?.Id;
        }
    }
}
