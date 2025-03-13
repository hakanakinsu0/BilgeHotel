using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IReservationExtraServiceManager : IManager<ReservationExtraServiceDto, ReservationExtraService>
    {
        Task<List<ReservationExtraServiceDto>> GetByReservationIdAsync(int reservationId);
        Task UpdateExtraServicesForReservation(int reservationId, List<int> newExtraServiceIds);
        Task UpdateDeletedAsync(ReservationExtraServiceDto dto);

    }
}
