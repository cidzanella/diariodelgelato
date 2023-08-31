using DiarioDelGelato.Application.Interfaces.Services;
using DiarioDelGelato.Infrastructure.Services;
using DiarioDelGelato.Infrastructure.Services.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DiarioDelGelato.Infrastructure
{
    public static class ServicesRegistration
    {
        // services extensions registration
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // email service
            // services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            // CSV file builder
            // DateTime service
            // USB Scale sevice
            services.AddSingleton<IUsbScaleService, UsbScaleService>();

        }

    }
}
