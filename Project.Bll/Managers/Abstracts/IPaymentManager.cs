using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    /// <summary>
    /// Otel ödemeleri ile ilgili işlemleri tanımlayan arayüzdür.
    /// Bu arayüz, ödeme kayıtlarını oluşturma, iptal etme, toplam gelir, son 30 gün geliri ve bekleyen ödemeleri hesaplama işlemlerini içerir.
    /// </summary>
    public interface IPaymentManager : IManager<PaymentDto, Payment>
    {
        /// <summary>
        /// Tüm ödemelerin toplam gelirini asenkron olarak hesaplar.
        /// </summary>
        /// <returns>Toplam gelir miktarı.</returns>
        Task<decimal> GetTotalRevenueAsync();

        /// <summary>
        /// Son 30 gün içerisindeki toplam geliri asenkron olarak hesaplar.
        /// </summary>
        /// <returns>Son 30 gün toplam gelir miktarı.</returns>
        Task<decimal> GetRevenueLast30DaysAsync();

        /// <summary>
        /// Bekleyen ödemelerin toplam tutarını asenkron olarak hesaplar.
        /// </summary>
        /// <returns>Bekleyen ödemelerin toplam tutarı.</returns>
        Task<decimal> GetPendingPaymentsAsync();

        /// <summary>
        /// Belirtilen rezervasyona ait ödeme kaydını oluşturur.
        /// </summary>
        /// <param name="reservationId">Ödeme kaydı oluşturulacak rezervasyonun ID'si.</param>
        /// <param name="amount">Ödeme tutarı.</param>
        /// <returns>Asenkron işlem tamamlandığında görev döner.</returns>
        Task RecordPaymentAsync(int reservationId, decimal amount);

        /// <summary>
        /// Belirtilen rezervasyon ID'sine ait ödeme kaydını iptal eder.
        /// </summary>
        /// <param name="reservationId">İptal edilecek rezervasyonun ID'si.</param>
        /// <returns>Asenkron işlem tamamlandığında görev döner.</returns>
        Task CancelPaymentByReservationIdAsync(int reservationId);
    }
}
