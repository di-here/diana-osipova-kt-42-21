using DianaOsipovaKT_42_21.Interfaces.WorkloadsInterfaces;
namespace DianaOsipovaKT_42_21.ServiceExtensions
{
    public static class SevrviceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkloadService, WorkloadService>();
            return services;
        }
    }
}
