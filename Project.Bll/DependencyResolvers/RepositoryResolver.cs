using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;
using System;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Repository katmanındaki bağımlılıkları çözümleyen extension metot.
    /// Tüm repository arayüzlerini (IRepository) ilgili somut repository (Concrete Repository) sınıfları ile ilişkilendirir.
    /// </summary>
    public static class RepositoryResolver
    {
        /// <summary>
        /// Repository bağımlılıklarını IServiceCollection'a ekler.
        /// IoC (Inversion of Control) Container'a her bir repository için Scoped (Request başına 1 instance) bağımlılık eklenir.
        /// </summary>
        public static void AddRepositoryService(this IServiceCollection services)
        {
            // Kullanıcı ve rol yönetimi repository bağımlılıkları
            services.AddScoped<IAppUserRepository, AppUserRepository>(); // 1 AppUser N Repository
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>(); // 1 AppUserProfile N Repository

            // **Kaldırılan Repository'ler:**
            // services.AddScoped<IAppRoleRepository, AppRoleRepository>(); ❌ SİLİNDİ
            // services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>(); ❌ SİLİNDİ

            // Müşteri yönetimi repository bağımlılıkları

            // Çalışan yönetimi repository bağımlılıkları
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // 1 Employee N Repository

            // Oda ve özellik yönetimi repository bağımlılıkları
            services.AddScoped<IRoomRepository, RoomRepository>(); // 1 Room N Repository
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>(); // 1 RoomType N Repository

            // Otel hizmetleri yönetimi repository bağımlılıkları
            services.AddScoped<IPackageRepository, PackageRepository>(); // 1 Package N Repository
            services.AddScoped<IPaymentRepository, PaymentRepository>(); // 1 Payment N Repository
            services.AddScoped<IReservationRepository, ReservationRepository>(); // 1 Reservation N Repository
        }
    }
}
