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
    /// InventoryItem işlemlerinin iş mantığını yöneten manager sınıfıdır.
    /// CRUD işlemleri ile birlikte özel filtrelemeler sağlar.
    /// </summary>
    public class InventoryItemManager : BaseManager<InventoryItemDto, InventoryItem>, IInventoryItemManager
    {
        private readonly IInventoryItemRepository _repository;

        public InventoryItemManager(IInventoryItemRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Belirli bir konumda bulunan donanım kayıtlarını döner.
        /// </summary>
        public async Task<List<InventoryItemDto>> GetByLocationAsync(string location)
        {
            var entities = await _repository
                .Where(x => x.Location == location)
                .Include(x => x.Employee)
                .ToListAsync();

            return _mapper.Map<List<InventoryItemDto>>(entities);
        }

        /// <summary>
        /// Belirli bir kategoriye (Bilgisayar, Server vb.) ait donanımları döner.
        /// </summary>
        public async Task<List<InventoryItemDto>> GetByCategoryAsync(string category)
        {
            var entities = await _repository
                .Where(x => x.Category == category)
                .Include(x => x.Employee)
                .ToListAsync();

            return _mapper.Map<List<InventoryItemDto>>(entities);
        }
    }
}