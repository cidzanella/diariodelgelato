using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using DiarioDelGelato.Application;
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
            services.AddInfrastructure(configuration);
            services.AddApplicationLayer();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddCors();
            services.RegisterApiVersioningService();
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

        private static IServiceCollection RegisterApiVersioningService(this IServiceCollection services)
        {
            // add versioned api explorer and then add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                // Configure how API version is read from requests
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),        // Reads version from URL segments
                    new HeaderApiVersionReader("x-api-version"),  // Reads version from custom header
                    new MediaTypeApiVersionReader("x-api-version") // Reads version from media type (Accept header)
                );
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
        
    }
}
