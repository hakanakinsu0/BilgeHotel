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
    public class PaymentManager : BaseManager<PaymentDto, Payment>, IPaymentManager
    {
        readonly IPaymentRepository _repository;
        public PaymentManager(IPaymentRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        //

        public async Task<decimal> GetTotalRevenueAsync()
        {
            return await SumAsync(p => p.PaymentAmount);
        }

        public async Task<decimal> GetRevenueLast30DaysAsync()
        {
            var startDate = DateTime.Today.AddDays(-30);
            return await SumAsync(p => p.PaymentAmount, p => p.PaymentDate >= startDate);
        }

        public async Task<decimal> GetPendingPaymentsAsync()
        {
            return await SumAsync(p => p.PaymentAmount, p => p.Reservation.ReservationStatus == Entities.Enums.ReservationStatus.PendingPayment);
        }

        /// <summary>
        /// Belirtilen rezervasyon için ödeme kaydını oluşturur veya günceller.
        /// Eğer var olan ödeme kaydı "Deleted" durumdaysa, güncelleyip aktif hale getirir;
        /// aksi halde yeni bir ödeme kaydı oluşturur.
        /// </summary>
        /// <param name="reservationId">Rezervasyon ID'si</param>
        /// <param name="amount">Ödeme tutarı</param>
        /// <returns>Asenkron işlem için Task</returns>
        public async Task RecordPaymentAsync(int reservationId, decimal amount)
        {
            // Tüm ödeme kayıtlarını getiriyoruz (BaseManager'dan gelen GetAllAsync kullanılabilir)
            var payments = await GetAllAsync(); // PaymentManager, BaseManager<PaymentDto, Payment>'ı miras alıyor
            var existingPayment = payments.FirstOrDefault(p => p.ReservationId == reservationId);

            if (existingPayment != null && existingPayment.Status == DataStatus.Deleted)
            {
                // Var olan ödeme kaydı güncelleniyor
                existingPayment.Status = DataStatus.Updated;
                existingPayment.ModifiedDate = DateTime.Now;
                existingPayment.DeletedDate = null;
                existingPayment.PaymentDate = DateTime.Now;
                await UpdateAsync(existingPayment);
            }
            else
            {
                // Yeni ödeme kaydı oluşturuluyor
                var paymentDto = new PaymentDto
                {
                    ReservationId = reservationId,
                    PaymentAmount = amount,
                    PaymentMethod = PaymentMethod.CreditCard,
                    PaymentDate = DateTime.Now,
                    Status = DataStatus.Inserted,
                    CreatedDate = DateTime.Now
                };
                await CreateAsync(paymentDto);
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
            // Repository üzerinden doğrudan, belirtilen rezervasyona ait ödeme kaydını çekiyoruz.
            // Burada, Where metodunu kullanarak filtreleme yapıyoruz.
            var payment = (await _repository.Where(p => p.ReservationId == reservationId).ToListAsync())
                                .FirstOrDefault();
            if (payment != null)
            {
                payment.Status = DataStatus.Deleted;
                payment.DeletedDate = DateTime.Now;
                await UpdateAsync(_mapper.Map<PaymentDto>(payment));
            }
        }



    }
}

