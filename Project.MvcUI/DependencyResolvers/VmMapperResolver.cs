using Project.MvcUI.VmMapping;

namespace Project.MvcUI.DependencyResolvers
{
    public static class VmMapperResolver
    {
        public static void AddVmMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VmMappingProfile));
        }
    }
}
