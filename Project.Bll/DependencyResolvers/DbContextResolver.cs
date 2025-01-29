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
    /// DbContext için Dependency Injection hizmetini çözümler.
    /// </summary>
    public static class DbContextResolver
    {
        /// <summary>
        /// DbContext'i IServiceCollection'a ekler.
        /// </summary>
        public static void AddDbContextService(this IServiceCollection services)
        {
            //ServiceProvider size bir hizmet saglayıcısı nesnesi sunarak istediginiz ayarlama dosyasına erişmenizin temelini atar

            ServiceProvider provider = services.BuildServiceProvider();

            IConfiguration configuration = provider.GetService<IConfiguration>();//bu noktadan itibaren artık set as startup olarak ayarlanmıs projenin appsettings.json dosyasına ulasma durumunuz acılmıstır...
            services.AddDbContext<MyContext>(x => x.UseSqlServer(configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());
        }
    }
}
