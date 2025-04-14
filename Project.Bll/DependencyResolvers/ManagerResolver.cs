using Microsoft.Extensions.DependencyInjection;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Tüm manager sınıflarının Dependency Injection'a eklenmesini sağlayan resolver sınıfı.
    /// İş mantığı (Business Logic Layer - BLL) bileşenlerini DI sistemine dahil eder.
    /// </summary>
    public static class ManagerResolver
    {
        /// <summary>
        /// Manager servislerini DI container'a ekler.
        /// </summary>
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        public static void AddManagerService(this IServiceCollection services)
        {
            // Manager Katmanı Bağımlılıkları
            // İş katmanındaki servislerin bağımlılıklar içinde çözülmesini sağlar.

            services.AddScoped<IAppUserManager, AppUserManager>();                  // Kullanıcı yönetimi
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();    // Kullanıcı profili yönetimi
            services.AddScoped<IEmployeeManager, EmployeeManager>();                // Çalışan yönetimi
            services.AddScoped<IRoomManager, RoomManager>();                        // Oda yönetimi
            services.AddScoped<IRoomTypeManager, RoomTypeManager>();                // Oda türü yönetimi
            services.AddScoped<IReservationManager, ReservationManager>();          // Rezervasyon yönetimi
            services.AddScoped<IPaymentManager, PaymentManager>();                  // Ödeme yönetimi
            services.AddScoped<IPackageManager, PackageManager>();                  // Paket yönetimi
            services.AddScoped<IExtraServiceManager, ExtraServiceManager>();        // Ekstra hizmetler yönetimi
            services.AddScoped<IReservationExtraServiceManager, ReservationExtraServiceManager>(); // Rezervasyon - Ekstra Hizmet yönetimi
            services.AddScoped<IDatabaseBackupLogManager, DatabaseBackupLogManager>(); //Database Loglama yönetimi

        }
    }
}
