using Project.Bll.DtoClasses;
using Project.Entities.Enums;
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

        Task<List<ReservationDto>> GetReservationReportsAsync();

        Task<(decimal TotalRevenue, List<(int Year, int Month, decimal TotalRevenue)> MonthlyReports)> GetRevenueReportsAsync();


        /// <summary>
        /// Tüm rezervasyon DTO'larını alır, eksik bilgileri tamamlar ve verilen filtre parametrelerine göre filtreler.
        /// Bu metot sayesinde controller, yalnızca eksik bilgileri tamamlanmış ve filtrelenmiş rezervasyon verisini alır.
        /// </summary>
        /// <param name="search">Kullanıcı adı veya e-posta araması</param>
        /// <param name="roomId">Oda numarasına göre filtre</param>
        /// <param name="status">Rezervasyon durumu filtre</param>
        /// <param name="isPaid">Ödeme durumu filtre (true: ödeme yapılmış, false: ödeme bekleniyor)</param>
        /// <returns>Filtrelenmiş ReservationDto listesini asenkron olarak döndürür.</returns>
        Task<List<ReservationDto>> GetFilteredReservationReportsAsync(string search, int? roomId, string status, bool? isPaid);


        /// <summary>
        /// Belirtilen rezervasyon bilgilerini, ekstra hizmetleri ve reaktivasyon durumunu dikkate alarak rezervasyonu günceller.
        /// Bu metot oda değişikliği, tarih kontrolü, fiyat hesaplaması, rezervasyon güncellemesi, ekstra hizmet güncellemesi ve
        /// gerekirse rezervasyonun reaktif edilmesi işlemlerini tek seferde gerçekleştirir.
        /// </summary>
        /// <param name="dto">Güncellenecek rezervasyon bilgilerini içeren ReservationDto</param>
        /// <param name="extraServiceIds">Rezervasyona eklenmek istenen ekstra hizmetlerin ID listesi</param>
        /// <param name="reactivateReservation">Rezervasyonun reaktif edilip edilmeyeceği</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığı</returns>
        Task<bool> UpdateReservationWithDetailsAsync(ReservationDto dto, List<int> extraServiceIds, bool reactivateReservation);


        /// <summary>
        /// Belirtilen rezervasyonun ödeme durumunu ve ilgili oda durumunu, yeni duruma göre günceller.
        /// Rezervasyon ve ödeme objelerinin durumları; Confirmed, PendingPayment ve Canceled durumlarına göre ayarlanır.
        /// Eğer yeni durum Canceled ise rezervasyon ve ödeme objeleri 'Deleted' statüsüne alınır ve oda boşaltılır.
        /// Eğer yeni durum PendingPayment veya Confirmed ise objeler Updated statüsüne alınır ve oda dolu olarak ayarlanır.
        /// </summary>
        /// <param name="reservationId">Güncellenecek rezervasyonun ID'si</param>
        /// <param name="newStatus">Yeni rezervasyon durumu (ReservationStatus)</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer</returns>
        Task<bool> UpdateReservationPaymentStatusAsync(int reservationId, ReservationStatus newStatus);


    }
}
