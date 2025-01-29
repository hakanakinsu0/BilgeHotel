using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Repository katmanındaki bağımlılıkları çözümleyen extension metot.
    /// </summary>
    public static class RepositoryResolver
    {
        /// <summary>
        /// Repository bağımlılıklarını IServiceCollection'a ekler.
        /// </summary>
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();
            services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDetailRepository, CustomerDetailRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeDetailRepository, EmployeeDetailRepository>();
            services.AddScoped<IEmployeeShiftRepository, EmployeeShiftRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomFeatureRepository, RoomFeatureRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IShiftRepository, ShiftRepository>();
        }
    }
}
