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
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly MyContext _context;

        public RoomRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Room> GetByRoomNumberAsync(string roomNumber)
        {
            return await _context.Set<Room>().FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
        }
    }
}
