using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Concretes
{
    /// <summary>
    /// PaymentManager sınıfı, ödeme işlemleriyle ilgili iş mantığını yönetir.
    /// Toplam gelir, son 30 günlük gelir, bekleyen ödemeler gibi finansal istatistikleri hesaplar.
    /// Ayrıca ödeme kaydı oluşturma, güncelleme ve iptal etme işlemlerini yürütür.
    /// Temel CRUD işlemleri BaseManager üzerinden sağlanır.
    /// </summary>
    public class PaymentManager : BaseManager<PaymentDto, Payment>, IPaymentManager
    {
        readonly IPaymentRepository _repository;
        public PaymentManager(IPaymentRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        /// <summary>
        /// Sistemdeki tüm ödeme kayıtlarının toplam gelirini hesaplar.
        /// </summary>
        /// <returns>Toplam gelir tutarı (decimal).</returns>
        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await SumAsync(p => p.PaymentAmount, p => p.Status != DataStatus.Deleted); // Sadece silinmemiş (aktif) ödemeler üzerinden toplam ödeme tutarını hesaplar.
        }

        /// <summary>
        /// Son 30 güne ait toplam geliri hesaplar.
        /// Ödeme tarihi bugünden geriye son 30 gün içinde olan kayıtların toplam ödeme tutarını döner.
        /// </summary>
        /// <returns>Son 30 günlük toplam ödeme tutarını decimal olarak döner.</returns>
        public async Task<decimal> GetRevenueLast30DaysAsync()
        {
            return await SumAsync(p => p.PaymentAmount, p => p.PaymentDate >= DateTime.Today.AddDays(-30)); // Ödeme tarihi son 30 gün içinde olan kayıtların toplam ödeme tutarını hesaplar.
        }

        /// <summary>
        /// Ödeme bekleyen rezervasyonlara ait toplam tahsil edilecek tutarı hesaplar.
        /// Reservation durumu "PendingPayment" olan kayıtların toplam ödeme tutarını döner.
        /// </summary>
        /// <returns>Ödeme bekleyen rezervasyonların toplam ödeme tutarını decimal olarak döner.</returns>
        public async Task<decimal> GetPendingPaymentsAsync()
        {
            return await SumAsync(p => p.PaymentAmount,p => p.Reservation.ReservationStatus == ReservationStatus.PendingPayment); // Durumu PendingPayment olan rezervasyonlara ait toplam ödeme tutarını hesaplar.
        }

        /// <summary>
        /// Belirtilen rezervasyon için ödeme kaydını oluşturur veya günceller.
        /// Eğer var olan ödeme kaydı "Deleted" durumdaysa, tekrar aktif hale getirir;
        /// aksi durumda yeni bir ödeme kaydı oluşturur.
        /// </summary>
        /// <param name="reservationId">İşlem yapılacak rezervasyonun ID'si.</param>
        /// <param name="amount">Ödeme tutarı.</param>
        /// <returns>Asenkron işlem task'ı döner.</returns>
        public async Task RecordPaymentAsync(int reservationId, decimal amount)
        {
            List<PaymentDto> payments = await GetAllAsync(); // Tüm ödeme kayıtlarını çekiyoruz.

            PaymentDto existingPayment = payments.FirstOrDefault(p => p.ReservationId == reservationId); // İlgili rezervasyona ait var olan bir ödeme kaydı olup olmadığını kontrol ediyoruz.

            // Eğer silinmiş bir ödeme kaydı varsa, onu yeniden aktif hale getiriyoruz.
            if (existingPayment != null && existingPayment.Status == DataStatus.Deleted)
            {
                existingPayment.Status = DataStatus.Updated;             // Güncel durum atanıyor.
                existingPayment.ModifiedDate = DateTime.Now;             // Güncellenme zamanı belirleniyor.
                existingPayment.DeletedDate = null;                      // Silinme tarihi temizleniyor.
                existingPayment.PaymentDate = DateTime.Now;              // Yeni ödeme tarihi atanıyor.

                await UpdateAsync(existingPayment);                      // Kayıt güncelleniyor.
            }
            else
            {
                // Eğer ödeme kaydı yoksa, yeni bir kayıt oluşturuluyor.
                PaymentDto paymentDto = new() 
                {
                    ReservationId = reservationId,                       // İlişkili rezervasyon
                    PaymentAmount = amount,                              // Tutar
                    PaymentMethod = PaymentMethod.CreditCard,            // Varsayılan olarak kredi kartı
                    PaymentDate = DateTime.Now,                          // Ödeme tarihi
                    Status = DataStatus.Inserted,                        // Durum inserted
                    CreatedDate = DateTime.Now                           // Oluşturulma tarihi
                };

                await CreateAsync(paymentDto);                           // Yeni ödeme kaydı oluşturuluyor.
            }
        }

        /// <summary>
        /// Belirtilen rezervasyon için ödeme kaydını iptal eder.
        /// İlgili ödeme kaydı bulunuyorsa, durumunu "Deleted" yapar ve DeletedDate alanını ayarlar.
        /// </summary>
        /// <param name="reservationId">İptal edilecek rezervasyonun ID'si</param>
        /// <returns>Asenkron işlem için Task</returns>
        public async Task CancelPaymentByReservationIdAsync(int reservationId)
        {
            // İlgili rezervasyona ait ilk aktif ödeme kaydını getiriyoruz.
            Payment payment = await _repository.Where(p => p.ReservationId == reservationId && p.Status != DataStatus.Deleted).FirstOrDefaultAsync();

            if (payment != null)
            {
                payment.Status = DataStatus.Deleted;
                payment.DeletedDate = DateTime.Now;
                
                await UpdateAsync(_mapper.Map<PaymentDto>(payment)); // Güncellenen entity'yi DTO'ya mapleyerek UpdateAsync'e iletiyoruz.
            }
        }
    }
}

