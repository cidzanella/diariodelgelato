using DiarioDelGelato.Application;
using DiarioDelGelato.Application.Validators.Identity;
using DiarioDelGelato.Infrastructure;
using DiarioDelGelato.Infrastructure.Persistance;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace DiarioDelGelato.WebAPI.AppStartup
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistanceInfrastructure(configuration);
            services.AddApplicationLayer();
            services.AddInfrastructure(configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.RegisterFluentValidationService();
            return services;
        }

        private static IServiceCollection RegisterFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<Program>(); //automaticaly will look for all validators in the assembly and they are located in Application layer at validators folder
            return services;
        }
    }
}
