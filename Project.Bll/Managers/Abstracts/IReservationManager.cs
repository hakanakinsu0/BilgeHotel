using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IReservationManager : IManager<ReservationDto, Reservation>
    {
        bool CheckAvailability(int roomId, DateTime startDate, DateTime endDate);
        Task<string> CreateReservation(ReservationDto dto);
        string ValidateReservationDates(DateTime startDate, DateTime endDate);
        Task<List<ReservationDto>> GetReservationsByUserIdAsync(int userId);
        Task<bool> CancelReservationAsync(int reservationId);
        Task<ReservationDto> GetLatestReservationByUserId(int userId);
        bool CheckAvailabilityForUpdate(int reservationId, int roomId, DateTime newStartDate, DateTime newEndDate);
        decimal CalculateUpdatedPrice(int roomId, DateTime startDate, DateTime endDate, int? packageId);
        Task<bool> UpdateReservationAsync(ReservationDto dto);

        //

        Task<int> GetTotalReservationCountAsync();
        Task<int> GetLast7DaysReservationCountAsync();
        Task<int> GetPendingReservationCountAsync();

        Task ReactivateReservationAsync(int reservationId);


    }
}
