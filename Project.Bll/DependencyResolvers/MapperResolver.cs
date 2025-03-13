using Microsoft.Extensions.DependencyInjection;
using Project.Bll.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.DependencyResolvers
{
    /// <summary>
    /// AutoMapper'ın DI container'a eklenmesini sağlayan resolver sınıfı.
    /// Nesneler arası dönüşümleri kolaylaştıran AutoMapper konfigürasyonunu sağlar.
    /// </summary>
    public static class MapperResolver
    {
        /// <summary>
        /// AutoMapper'ı servis koleksiyonuna ekler.
        /// </summary>
        /// <param name="services">Bağımlılık enjeksiyonuna eklenecek servis koleksiyonu.</param>
        public static void AddMapperServices(this IServiceCollection services)
        {
            // AutoMapper Entegrasyonu
            // `MappingProfile` sınıfını kullanarak, nesneler arası dönüşüm yapılandırmalarını DI container'a ekler.
            // Bu sayede AutoMapper, tüm projede bağımlılık enjeksiyonuna dahil edilerek kullanılabilir hale gelir.

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
