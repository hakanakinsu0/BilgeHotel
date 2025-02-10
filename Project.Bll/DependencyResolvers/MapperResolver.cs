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
    /// </summary>
    public static class MapperResolver
    {
        /// <summary>
        /// AutoMapper'ı servis koleksiyonuna ekler.
        /// </summary>
        public static void AddMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile)); // MappingProfile'ı tanımlıyoruz
        }
    }
}
