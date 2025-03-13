using AutoMapper;
using Project.Bll.DtoClasses;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
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
    }
}

