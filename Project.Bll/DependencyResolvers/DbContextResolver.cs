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
    /// Veritabanı bağlamı(DbContext) için Dependency Injection(DI) hizmetini çözümler.
    /// Uygulamanın DI sistemine DbContext ekleyerek, tüm bileşenlerin veritabanı ile iletişim kurmasını sağlar.
    /// </summary>
    public static class DbContextResolver
    {
        /// <summary>
        /// DbContext'i IServiceCollection'a ekler ve veritabanı bağlantısını yapılandırır.
        /// </summary>
        public static void AddDbContextService(this IServiceCollection services)
        {
            // ServiceProvider Kullanımı
            // ServiceProvider, Dependency Injection (DI) konteynerinden servisleri almak için kullanılır.
            // Bu satır ile DI sisteminde yapılandırılmış servisleri içeren bir `provider` nesnesi oluşturuluyor.
            ServiceProvider provider = services.BuildServiceProvider();

            // IConfiguration Kullanımı
            // IConfiguration, uygulamanın appsettings.json dosyasından ayarları okumak için kullanılır.
            // Burada ServiceProvider aracılığıyla IConfiguration servisi elde ediliyor.
            IConfiguration configuration = provider.GetService<IConfiguration>();

            // DbContext'i DI Konteynerine Ekleme
            // Burada MyContext sınıfı, UseSqlServer ile SQL Server bağlantısı kullanılarak DI sistemine ekleniyor.
            // Ayrıca UseLazyLoadingProxies() kullanılarak Lazy Loading aktif hale getiriliyor.
            services.AddDbContext<MyContext>(x => x.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
        }
    }
}