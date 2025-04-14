using Microsoft.Extensions.DependencyInjection;
using Project.Dal.Repositories.Abstracts;
using Project.Dal.Repositories.Concretes;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Repository katmanındaki bağımlılıkları çözümleyen extension metot.
    /// Tüm soyut repository arayüzlerini (Abstract) ilgili somut repository (Concrete Repository) sınıfları ile ilişkilendirerek Dependency Injection (DI) sistemine ekler.
    /// </summary>
    public static class RepositoryResolver
    {
        /// <summary>
        /// Repository bağımlılıklarını IServiceCollection'a ekler.
        /// IoC (Inversion of Control) Container'a her bir repository için Scoped (Request başına 1 instance) bağımlılık eklenir.
        /// </summary>
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        public static void AddRepositoryService(this IServiceCollection services)
        {
            // Kullanıcı ve Rol Yönetimi Repository Bağımlılıkları
            // Kullanıcılar ve kullanıcı profilleri için bağımlılıklar DI sistemine ekleniyor.
            services.AddScoped<IAppUserRepository, AppUserRepository>();                // Kullanıcı yönetimi
            services.AddScoped<IAppUserProfileRepository, AppUserProfileRepository>();  // Kullanıcı profili yönetimi

            // Çalışan Yönetimi Repository Bağımlılıkları
            services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // Çalışan yönetimi

            // Oda ve Oda Türü Yönetimi Repository Bağımlılıkları
            services.AddScoped<IRoomRepository, RoomRepository>();          // Oda yönetimi
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();  // Oda türü yönetimi

            // Otel Hizmetleri Yönetimi Repository Bağımlılıkları
            services.AddScoped<IPackageRepository, PackageRepository>();            // Paket yönetimi
            services.AddScoped<IPaymentRepository, PaymentRepository>();            // Ödeme yönetimi
            services.AddScoped<IReservationRepository, ReservationRepository>();    // Rezervasyon yönetimi

            // Ekstra Hizmetler ve Rezervasyon Hizmetleri Yönetimi
            services.AddScoped<IExtraServiceRepository, ExtraServiceRepository>();                          // Ekstra hizmetler yönetimi
            services.AddScoped<IReservationExtraServiceRepository, ReservationExtraServiceRepository>();    // Rezervasyon - Ekstra Hizmet yönetimi

            // Database Yedekleme Log Yönetimi Repository Bağımlılıkları
            services.AddScoped<IDatabaseBackupLogRepository, DatabaseBackupLogRepository>(); // Database Loglama yönetimi

        }
    }
}
