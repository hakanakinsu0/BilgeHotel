using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Rezervasyonlara eklenen ekstra hizmetlerle ilgili işlemleri tanımlayan arayüzdür.
    /// Bu arayüz, genel CRUD işlemlerini IManager üzerinden miras alır ve ekstra olarak
    /// rezervasyona bağlı ekstra hizmetlerin yönetimi için özel metotları içerir.
    /// </summary>
    public interface IReservationExtraServiceManager : IManager<ReservationExtraServiceDto, ReservationExtraService>
    {
        /// <summary>
        /// Belirtilen rezervasyon ID'sine ait ekstra hizmetleri asenkron olarak getirir.
        /// </summary>
        /// <param name="reservationId">Ekstra hizmetleri getirilecek rezervasyonun ID'si.</param>
        /// <returns>Rezervasyona ait ekstra hizmetlerin DTO listesini döndürür.</returns>
        Task<List<ReservationExtraServiceDto>> GetByReservationIdAsync(int reservationId);

        /// <summary>
        /// Belirtilen rezervasyon için ekstra hizmet ID'lerini günceller.
        /// Yeni ekstra hizmet ID'leri ile mevcut kayıtları güncelleyerek rezervasyonun ekstra hizmetlerini ayarlar.
        /// </summary>
        /// <param name="reservationId">Güncellenecek rezervasyonun ID'si.</param>
        /// <param name="newExtraServiceIds">Yeni ekstra hizmet ID'lerinin listesi.</param>
        Task UpdateExtraServicesForReservation(int reservationId, List<int> newExtraServiceIds);

        /// <summary>
        /// Belirtilen ekstra hizmet kaydının silindi (pasif) olarak işaretlenmesini günceller.
        /// </summary>
        /// <param name="dto">Silinecek ekstra hizmetin DTO'su.</param>
        Task UpdateDeletedAsync(ReservationExtraServiceDto dto);

        /// <summary>
        /// Belirtilen rezervasyon ID'sine ait tüm ekstra hizmetleri iptal eder.
        /// Bu metod, rezervasyonla ilişkili ekstra hizmetlerin pasif hale getirilmesini sağlar.
        /// </summary>
        /// <param name="reservationId">İptal edilecek rezervasyonun ID'si.</param>
        Task CancelExtraServicesByReservationIdAsync(int reservationId);
    }
}
