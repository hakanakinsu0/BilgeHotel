using Microsoft.Extensions.DependencyInjection;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Tüm manager sınıflarının Dependency Injection'a eklenmesini sağlayan resolver sınıfı.
    /// </summary>
    public static class ManagerResolver
    {
        /// <summary>
        /// Manager servislerini DI container'a ekler.
        /// </summary>
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();


            services.AddScoped<IEmployeeManager, EmployeeManager>();

            services.AddScoped<IRoomManager, RoomManager>();
            services.AddScoped<IRoomTypeManager, RoomTypeManager>();

            services.AddScoped<IReservationManager, ReservationManager>();
            services.AddScoped<IPaymentManager, PaymentManager>();
            services.AddScoped<IPackageManager, PackageManager>();

        }
    }
}


