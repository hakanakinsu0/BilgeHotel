using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Dal.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// Veritabanı bağlamı (DbContext) için Dependency Injection (DI) hizmetini çözümler.
    /// Uygulamanın DI sistemine DbContext ekleyerek, tüm bileşenlerin veritabanı ile iletişim kurmasını sağlar.
    /// </summary>
    public static class DbContextResolver
    {
        /// <summary>
        /// DbContext'i IServiceCollection'a ekler ve veritabanı bağlantısını yapılandırır.
        /// </summary>
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        /// <param name="configuration">Veritabanı bağlantı ayarlarını içeren IConfiguration nesnesi.</param>
        public static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext'i DI Konteynerine Ekleme
            // `MyContext` sınıfı, `UseSqlServer` ile SQL Server bağlantısı kullanılarak DI sistemine ekleniyor.
            // `UseLazyLoadingProxies()` kullanılarak Lazy Loading aktif hale getiriliyor.
            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyConnection"))
                       .UseLazyLoadingProxies());
        }
    }
}