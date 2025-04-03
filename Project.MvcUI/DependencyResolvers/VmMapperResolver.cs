using Microsoft.Extensions.DependencyInjection;
using Project.MvcUI.VmMapping;

namespace Project.MvcUI.DependencyResolvers
{
    /// <summary>
    /// ViewModel katmanındaki AutoMapper profilini DI konteynerine eklemek için kullanılan genişletme sınıfıdır.
    /// </summary>
    public static class VmMapperResolver
    {
        /// <summary>
        /// AutoMapper konfigürasyonunu ViewModel Mapping profiliyle birlikte servislere ekler.
        /// </summary>
        /// <param name="services">IServiceCollection nesnesi</param>
        public static void AddVmMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VmMappingProfile));
        }
    }
}
