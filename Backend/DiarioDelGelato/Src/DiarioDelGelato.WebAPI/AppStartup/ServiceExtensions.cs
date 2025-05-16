using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using DiarioDelGelato.Application;
using DiarioDelGelato.Infrastructure;
using DiarioDelGelato.Infrastructure.Persistance;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.OpenApi.Models;
using DiarioDelGelato.Application.Common;

namespace DiarioDelGelato.WebAPI.AppStartup
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistanceInfrastructure(configuration);
            services.AddInfrastructure(configuration); // authentication is added here
            services.RegisterAuthorizationService();
            services.AddApplicationLayer();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddCors();
            services.RegisterSwaggerGen();
            services.RegisterFluentValidationService();
            services.RegisterApiVersioningService();
            return services;
        }

        private static IServiceCollection RegisterAuthorizationService(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy =>
                    policy.RequireRole("Admin"));

                options.AddPolicy("RequireUserRole", policy =>
                    policy.RequireRole("User"));

                options.AddPolicy("RequireAdminOrUser", policy =>
                    policy.RequireRole("Admin", "User"));

                options.AddPolicy("RequireCustomClaim", policy =>
                    policy.RequireClaim("CustomClaimType", "CustomClaimValue"));
            });

            return services;
        }

        private static IServiceCollection RegisterSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DiarioDelGelato.WebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
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

        private static IServiceCollection RegisterFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            //automaticaly will look for all validators in the assembly and they are located in Application layer at validators folder
            services.AddValidatorsFromAssemblyContaining<AssemblyReference>();
            return services;
        }
    }
}
