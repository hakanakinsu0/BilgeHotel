using Project.Bll.DtoClasses;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IRoomManager : IManager<RoomDto, Room> 
    {

        Task<int> GetTotalRoomCountAsync();
        Task<int> GetEmptyRoomCountAsync();
        Task<int> GetOccupiedRoomCountAsync();
        Task<int> GetMaintenanceRoomCountAsync();
        Task<RoomDto> GetByRoomNumberAsync(string roomNumber);


        Task<bool> CanDeleteRoomAsync(int roomId);
        Task<bool> UpdateRoomStatusAsync(int roomId, RoomStatus newStatus);

        Task<List<RoomDto>> GetAvailableRoomsAsync(DateTime startDate, DateTime endDate);

    }

}
