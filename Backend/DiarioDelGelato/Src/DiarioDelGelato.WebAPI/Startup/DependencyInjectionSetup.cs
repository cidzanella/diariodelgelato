using DiarioDelGelato.Application;
using DiarioDelGelato.Infrastructure;
using DiarioDelGelato.Infrastructure.Persistance;

namespace DiarioDelGelato.WebAPI.Startup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistanceInfrastructure(configuration);
            services.AddApplicationLayer();
            services.AddInfrastructure(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
