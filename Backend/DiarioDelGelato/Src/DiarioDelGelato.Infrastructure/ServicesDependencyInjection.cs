using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DiarioDelGelato.Infrastructure
{
    public static class ServicesDependencyInjection
    {
        // services extensions registration
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            // email service
            // CSV file builder
            // DateTime service
            // USB Scale sevice
            services.AddSingleton<IUsbScaleService, UsbScaleService>();

        }

    }
}
