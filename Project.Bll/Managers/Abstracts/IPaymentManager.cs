using Project.Bll.DtoClasses;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Managers.Abstracts
{
    public interface IPaymentManager : IManager<PaymentDto, Payment> 
    {
        Task<decimal> GetTotalRevenueAsync();
        Task<decimal> GetRevenueLast30DaysAsync();
        Task<decimal> GetPendingPaymentsAsync();
    }

}
