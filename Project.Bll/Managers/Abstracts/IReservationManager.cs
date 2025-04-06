using Project.Bll.DtoClasses;
using Project.Entities.Models;
using Project.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Otel rezervasyonlarına ilişkin iş mantığı işlemlerini tanımlayan arayüzdür.
    /// Bu arayüz, rezervasyon oluşturma, iptal, güncelleme, fiyat hesaplama, raporlama ve ödeme durumu kontrolleri gibi 
    /// çeşitli işlemleri kapsar.
    /// </summary>
    public interface IReservationManager : IManager<ReservationDto, Reservation>
    {
        /// <summary>
        /// Belirtilen oda, başlangıç ve bitiş tarihleri arasında oda müsaitliğini kontrol eder.
        /// </summary>
        /// <param name="roomId">Oda ID'si.</param>
        /// <param name="startDate">Rezervasyon başlangıç tarihi.</param>
        /// <param name="endDate">Rezervasyon bitiş tarihi.</param>
        /// <returns>Müsaitse true, değilse false.</returns>
        bool CheckAvailability(int roomId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Yeni bir rezervasyon oluşturur.
        /// </summary>
        /// <param name="dto">Oluşturulacak rezervasyon bilgilerini içeren DTO.</param>
        /// <returns>Rezervasyon oluşturma işlemi hakkında bilgi mesajı.</returns>
        Task<string> CreateReservation(ReservationDto dto);

        /// <summary>
        /// Rezervasyon tarihlerini doğrular.
        /// </summary>
        /// <param name="startDate">Rezervasyon başlangıç tarihi.</param>
        /// <param name="endDate">Rezervasyon bitiş tarihi.</param>
        /// <returns>Eğer tarih aralığı geçerli değilse hata mesajı, geçerliyse null döner.</returns>
        string ValidateReservationDates(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Belirtilen kullanıcı ID'sine ait rezervasyonları asenkron olarak getirir.
        /// </summary>
        /// <param name="userId">Kullanıcı ID'si.</param>
        /// <returns>Kullanıcının rezervasyonlarını içeren DTO listesini döndürür.</returns>
        Task<List<ReservationDto>> GetReservationsByUserIdAsync(int userId);

        /// <summary>
        /// Belirtilen rezervasyonu iptal eder.
        /// </summary>
        /// <param name="reservationId">İptal edilecek rezervasyonun ID'si.</param>
        /// <returns>İptal işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> CancelReservationAsync(int reservationId);

        /// <summary>
        /// Belirtilen kullanıcı için en son oluşturulan rezervasyonu asenkron olarak getirir.
        /// </summary>
        /// <param name="userId">Kullanıcı ID'si.</param>
        /// <returns>En son oluşturulan rezervasyonun DTO'su.</returns>
        Task<ReservationDto> GetLatestReservationByUserId(int userId);

        /// <summary>
        /// Rezervasyon güncellemesi sırasında oda müsaitliğini kontrol eder.
        /// </summary>
        /// <param name="reservationId">Güncellenmek istenen rezervasyonun ID'si.</param>
        /// <param name="roomId">Yeni oda ID'si.</param>
        /// <param name="newStartDate">Yeni rezervasyon başlangıç tarihi.</param>
        /// <param name="newEndDate">Yeni rezervasyon bitiş tarihi.</param>
        /// <returns>Müsaitse true, değilse false.</returns>
        bool CheckAvailabilityForUpdate(int reservationId, int roomId, DateTime newStartDate, DateTime newEndDate);

        /// <summary>
        /// Belirtilen oda ve tarih bilgilerine göre, rezervasyonun güncellenmiş fiyatını hesaplar.
        /// </summary>
        /// <param name="roomId">Oda ID'si.</param>
        /// <param name="startDate">Rezervasyon başlangıç tarihi.</param>
        /// <param name="endDate">Rezervasyon bitiş tarihi.</param>
        /// <param name="packageId">Seçilen paket ID'si (varsa).</param>
        /// <returns>Hesaplanan güncellenmiş fiyat.</returns>
        decimal CalculateUpdatedPrice(int roomId, DateTime startDate, DateTime endDate, int? packageId);

        /// <summary>
        /// Mevcut rezervasyon bilgilerini günceller.
        /// </summary>
        /// <param name="dto">Güncellenecek rezervasyon bilgilerini içeren DTO.</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> UpdateReservationAsync(ReservationDto dto);

        /// <summary>
        /// Toplam rezervasyon sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Toplam rezervasyon sayısı.</returns>
        Task<int> GetTotalReservationCountAsync();

        /// <summary>
        /// Son 7 gün içerisinde oluşturulan rezervasyon sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Son 7 gün rezervasyon sayısı.</returns>
        Task<int> GetLast7DaysReservationCountAsync();

        /// <summary>
        /// Ödeme bekleyen rezervasyon sayısını asenkron olarak getirir.
        /// </summary>
        /// <returns>Ödeme bekleyen rezervasyon sayısı.</returns>
        Task<int> GetPendingReservationCountAsync();

        /// <summary>
        /// İptal edilmiş rezervasyonu yeniden aktif hale getirir.
        /// </summary>
        /// <param name="reservationId">Reaktif edilecek rezervasyonun ID'si.</param>
        /// <returns>Reaktif işleminin tamamlanması için asenkron görev.</returns>
        Task ReactivateReservationAsync(int reservationId);

        /// <summary>
        /// Rezervasyonun toplam fiyatına, seçilen ekstra hizmetlerin ücretlerini ve gece sayısını çarparak ekler.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si.</param>
        /// <param name="extraServiceIds">Rezervasyona eklenmek istenen ekstra hizmetlerin ID listesi.</param>
        /// <returns>Asenkron işlem tamamlandığında görev döner.</returns>
        Task UpdateReservationPriceWithExtraServices(int reservationId, List<int> extraServiceIds);

        /// <summary>
        /// Rezervasyonun ödeme işlemi için uygun olup olmadığını kontrol eder.
        /// Rezervasyon onaylanmış veya iptal edilmiş durumdaysa ödeme yapılamaz.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si.</param>
        /// <returns>Eğer uygun ise true, değilse false.</returns>
        Task<bool> IsReservationPayableAsync(int reservationId);

        /// <summary>
        /// Rezervasyonu onaylar.
        /// </summary>
        /// <param name="reservationId">Onaylanacak rezervasyonun ID'si.</param>
        /// <returns>Asenkron işlem tamamlandığında görev döner.</returns>
        Task ConfirmReservationAsync(int reservationId);

        /// <summary>
        /// Belirtilen rezervasyon ID'sine sahip, onaylanmış rezervasyonun detaylarını asenkron olarak getirir.
        /// </summary>
        /// <param name="reservationId">Onaylanmış rezervasyonun ID'si.</param>
        /// <returns>Onaylanmış rezervasyonun detaylarını taşıyan DTO.</returns>
        Task<ReservationDto> GetConfirmedReservationByIdAsync(int reservationId);

        /// <summary>
        /// Rezervasyon raporları oluşturmak için tüm rezervasyon DTO'larını asenkron olarak getirir.
        /// </summary>
        /// <returns>Rezervasyon DTO'larının listesini döndürür.</returns>
        Task<List<ReservationDto>> GetReservationReportsAsync();

        /// <summary>
        /// Rezervasyon gelir raporlarını hesaplar; toplam gelir ve aylık bazda gelir raporlarını döndürür.
        /// </summary>
        /// <returns>Toplam gelir ve aylık gelir raporlarını içeren bir tuple.</returns>
        Task<(decimal TotalRevenue, List<(int Year, int Month, decimal TotalRevenue)> MonthlyReports)> GetRevenueReportsAsync();

        /// <summary>
        /// Belirtilen filtre parametrelerine göre eksik bilgileri tamamlanmış rezervasyon DTO'larını asenkron olarak getirir.
        /// Bu metot, controller'ın filtreleme işlemlerini basitleştirmek için kullanılır.
        /// </summary>
        /// <param name="search">Müşteri adı veya e-posta araması.</param>
        /// <param name="isPaid">Ödeme durumu filtresi (true: ödenmiş, false: bekliyor).</param>
        /// <returns>Filtrelenmiş rezervasyon DTO'larının listesini döndürür.</returns>
        Task<List<ReservationDto>> GetFilteredReservationReportsAsync(string search, bool? isPaid);


        /// <summary>
        /// Belirtilen rezervasyon bilgilerini, ekstra hizmetleri ve reaktivasyon durumunu dikkate alarak rezervasyonu günceller.
        /// Bu metot, oda değişikliği, tarih kontrolü, fiyat hesaplaması, rezervasyon güncellemesi, ekstra hizmet güncellemesi ve
        /// gerekirse rezervasyonun reaktif edilmesi işlemlerini tek seferde gerçekleştirir.
        /// </summary>
        /// <param name="dto">Güncellenecek rezervasyon bilgilerini içeren DTO.</param>
        /// <param name="extraServiceIds">Rezervasyona eklenmek istenen ekstra hizmetlerin ID listesi.</param>
        /// <param name="reactivateReservation">Rezervasyonun reaktif edilip edilmeyeceğini belirten bayrak.</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> UpdateReservationWithDetailsAsync(ReservationDto dto, List<int> extraServiceIds, bool reactivateReservation);

        /// <summary>
        /// Belirtilen rezervasyonun ödeme ve oda durumunu, yeni duruma göre günceller.
        /// Rezervasyon ve ödeme objelerinin durumu; Confirmed, PendingPayment ve Canceled durumlarına göre ayarlanır.
        /// Eğer yeni durum Canceled ise, rezervasyon ve ödeme objeleri 'Deleted' statüsüne alınır ve oda boşaltılır.
        /// Eğer yeni durum PendingPayment veya Confirmed ise, objeler Updated statüsüne alınır ve oda dolu olarak ayarlanır.
        /// </summary>
        /// <param name="reservationId">Güncellenecek rezervasyonun ID'si.</param>
        /// <param name="newStatus">Yeni rezervasyon durumu (ReservationStatus).</param>
        /// <returns>Güncelleme işleminin başarılı olup olmadığını belirten boolean değer.</returns>
        Task<bool> UpdateReservationPaymentStatusAsync(int reservationId, ReservationStatus newStatus);

        Task<ReservationDto> GetDetailedReservationByIdAsync(int id);

    }
}
