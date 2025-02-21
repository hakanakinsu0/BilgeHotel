using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Repository katmanındaki bağımlılıkları çözümleyen extension metot.
    /// Tüm repository arayüzlerini (IRepository) ilgili somut repository
    /// (Concrete Repository) sınıfları ile ilişkilendirir.
    /// </summary>
    public static class RepositoryResolver
    {
        /// <summary>
        /// Repository bağımlılıklarını IServiceCollection'a ekler.
        /// IoC (Inversion of Control) Container'a her bir repository için Scoped
        /// (Request başına 1 instance) bağımlılık eklenir.
        /// </summary>
        public static void AddRepositoryService(this IServiceCollection services)
        {
            // Kullanıcı ve rol yönetimi repository bağımlılıkları
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();

            // Çalışan yönetimi repository bağımlılıkları
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Oda ve özellik yönetimi repository bağımlılıkları
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            // Otel hizmetleri yönetimi repository bağımlılıkları
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            // **Yeni Eklenen Repository'ler**
            services.AddScoped<IExtraServiceRepository, ExtraServiceRepository>();
            services.AddScoped<IReservationExtraServiceRepository, ReservationExtraServiceRepository>();
        }
    }
}
