using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IReservationManager : IManager<ReservationDto, Reservation>
    {
        bool CheckAvailability(int roomId, DateTime startDate, DateTime endDate);
        Task<string> CreateReservation(ReservationDto dto);
    }
}
