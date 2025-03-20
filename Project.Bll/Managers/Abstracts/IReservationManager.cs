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

        /// <summary>
        /// Rezervasyonun toplam fiyatına, seçilen ekstra hizmetlerin ücretlerini gece sayısıyla çarparak ekler.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <param name="extraServiceIds">Ekstra hizmetlerin ID listesi</param>
        /// <returns>Asenkron işlem için Task</returns>
        Task UpdateReservationPriceWithExtraServices(int reservationId, List<int> extraServiceIds);

        /// <summary>
        /// Rezervasyonun ödeme işlemi için uygun olup olmadığını kontrol eder.
        /// Rezervasyon, onaylanmış veya iptal edilmiş durumdaysa ödeme yapılamaz.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <returns>Uygunsa true, değilse false</returns>
        Task<bool> IsReservationPayableAsync(int reservationId);

        Task ConfirmReservationAsync(int reservationId);

        Task<ReservationDto> GetConfirmedReservationByIdAsync(int reservationId);







    }
}
